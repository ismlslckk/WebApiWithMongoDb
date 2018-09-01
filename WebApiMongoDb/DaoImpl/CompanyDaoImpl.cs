using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebApiMongoDb.Dao;
using WebApiMongoDb.Data;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.DaoImpl
{
    public class CompanyDaoImpl:ICompanyDao
    {
        private readonly DataContext _dataContext;
        public IMongoCollection<Company> CompanyCollection;

        public CompanyDaoImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
            CompanyCollection = dataContext.GetCollection<Company>();

        }

        public IEnumerable<Company> All()
        {
            return CompanyCollection.AsQueryable().ToList().Take(250);
        }

        public void Add(Company p)
        {
            CompanyCollection.InsertOne(p);
        }

        public void Update(Company p)
        {
            //var filter = Builders<Product>.Update
            //    .Set(x => x.CategoryId, p.CategoryId)
            //    .Set(x => x.Date, p.Date)
            //    .Set(x => x.Name, p.Name)
            //    .Set(x => x.Price, p.Price)
            //    .Set(x => x.Quantity, p.Quantity)
            //    .Set(x => x.Status, p.Status);

            //CompanyCollection.UpdateMany(x => x.Id == p.Id, filter);
        }

        public void Delete(string id)
        {
            var filter = Builders<Company>.Filter.And(
                Builders<Company>.Filter.Eq("Id", id));
            // ProductCollection.DeleteOne(x => x.Id == id); //tek koşula bağlı olarak silme
            CompanyCollection.DeleteOne(filter);
        }
    }
}
