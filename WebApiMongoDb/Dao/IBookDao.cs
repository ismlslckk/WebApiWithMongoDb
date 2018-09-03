using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Dao
{
    public interface IBookDao:ICrud<Book>
    {
        List<Book> ListByFeatures(Book b, string orderBy);

        List<object> GroupBy(string columns);

        long TotalCount();

        string CreateIndexByColumn(string column);

        object CreateIndexByColumn(string[] column);

        IEnumerable<string> Indexs();
    }
}
