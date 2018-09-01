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
    public class ProductDaoImpl : IProductDao
    {

        private readonly DataContext _dataContext;
        public IMongoCollection<Product> ProductCollection;

        public ProductDaoImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
            ProductCollection = dataContext.GetCollection<Product>();

        }

        public IEnumerable<Product> All()
        {
            return ProductCollection.AsQueryable().ToList();
        }

        public void Add(Product p)
        {
            ProductCollection.InsertOne(p);
        }

        public void Update(Product p)
        {
            var filter = Builders<Product>.Update
                    .Set(x => x.CategoryId, p.CategoryId)
                    .Set(x => x.Date, p.Date)
                    .Set(x => x.Name, p.Name)
                    .Set(x => x.Price, p.Price)
                    .Set(x => x.Quantity, p.Quantity)
                    .Set(x => x.Status, p.Status);

            ProductCollection.UpdateMany(x => x.Id == p.Id, filter);
        }

        public void Delete(string id)
        {
            var filter = Builders<Product>.Filter.And(
                    Builders<Product>.Filter.Eq("Id", id),
                    Builders<Product>.Filter.Eq("name", "dedede"));
            // ProductCollection.DeleteOne(x => x.Id == id); //tek koşula bağlı olarak silme
            ProductCollection.DeleteOne(filter);
        }

        public Product GetById(string id)
        {
            return ProductCollection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
    }
}
