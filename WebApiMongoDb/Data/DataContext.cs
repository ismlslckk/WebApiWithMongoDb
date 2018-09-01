using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebApiMongoDb.Data
{
    public class DataContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public DataContext()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = mongoClient.GetDatabase("Library");
        }

        public IMongoDatabase Database()
        {
            return _mongoDatabase;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name);
        }


    }
}
