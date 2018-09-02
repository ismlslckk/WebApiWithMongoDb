using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using WebApiMongoDb.Dao;
using WebApiMongoDb.Data;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.DaoImpl
{
    public class BookDaoImpl : IBookDao
    {
        private readonly DataContext _dataContext;
        public IMongoCollection<Book> BookCollection;

        public BookDaoImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
            BookCollection = dataContext.GetCollection<Book>();

        }

        public IEnumerable<Book> All()
        {
            return BookCollection.AsQueryable().ToList();
        }

        public void Add(Book b)
        {
            BookCollection.InsertOne(b);
        }

        public void Update(Book b)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in b.GetType().GetProperties())
            {
                filter.Add(propertyInfo.Name, propertyInfo.GetValue(b));
            }

            BookCollection.ReplaceOne(x => x.Id == b.Id, b);
        }

        public void Delete(string id)
        {
            BookCollection.DeleteOne(x => x.Id == id);
        }

        public Book GetById(string id)
        {
            return BookCollection.AsQueryable().FirstOrDefault(x => x.Id == id);

        }

        public List<Book> ListByFeatures(Book b, string orderBy)
        {
            //örnek orderBy değeri => title:1 ise title'a göre asc uygular title:-1 ise title'a göre desc uygular.
            Dictionary<string, object> features = new Dictionary<string, object>();

            foreach (PropertyInfo propertyInfo in b.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(b) != null && propertyInfo.GetValue(b).ToString() != "-1" &&
                    propertyInfo.GetValue(b).ToString() != "1.01.0001 00:00:00")
                {
                    object[] attrs = propertyInfo.GetCustomAttributes(true);
                    BsonElementAttribute be = (BsonElementAttribute)attrs[0];
                    features.Add(be.ElementName, propertyInfo.GetValue(b));
                }
            }

            if (orderBy != null && orderBy.Split(":").Length == 2)
                return BookCollection.Find(new BsonDocument(features)).Sort("{" + orderBy + "}").ToList();

            return BookCollection.Find(new BsonDocument(features)).ToList();

        }

        public List<object> GroupBy(string columns)
        {
            List<object> response = new List<object>();
            Dictionary<string, object> keys = new Dictionary<string, object>();
            foreach (string column in columns.Split("~"))
            {
                keys.Add(column, "$" + column);
            }
            var grouping = new BsonDocument {
                { "_id", new BsonDocument(keys) },
                { "count", new BsonDocument("$sum", 1)  }/*,
                { "pageCountTotal", new BsonDocument("$sum", "$pageCount")  }*/
            };
            var agbrands = BookCollection.Aggregate().Group(grouping).ToList();

            foreach (BsonDocument bd in agbrands)
            {
                dynamic jsonObject = new JObject();
                foreach (KeyValuePair<string, object> entry in keys)
                {
                    jsonObject[entry.Key] = bd["_id"][entry.Key].ToString();
                }

                jsonObject["count"] = bd["count"].ToString();
                response.Add(jsonObject);
            }

            return response;


            //var result = BookCollection.Aggregate()
            //    .Group(
            //        x => x.Title,
            //        g => new {
            //            Title = g.Select(
            //                x => x.Title
            //            ).First(),
            //            TotalPageCount = g.Sum(
            //                x => x.PageCount
            //            ),
            //            Count=g.Count()
            //        }
            //    ).ToList();

            //return result;
        }
    }
}
