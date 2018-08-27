using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiMongoDb.Models;


namespace WebApiMongoDb.DAO
{
    public interface IProductDao
    {
        IEnumerable<Product> All();
        void Add(Product p);
        void Update(Product p);
        void Delete(string id);
    }
}
