using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
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

            if (orderBy!=null && orderBy.Split(":").Length == 2)
                return BookCollection.Find(new BsonDocument(features)).Sort("{"+orderBy+"}").ToList();

            return BookCollection.Find(new BsonDocument(features)).ToList();

        }
    }
}
