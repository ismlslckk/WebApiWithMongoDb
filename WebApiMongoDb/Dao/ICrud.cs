using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMongoDb.Dao
{
    public interface ICrud<T>
    {
        IEnumerable<T> All();
        void Add(T p);
        void Update(T p);
        void Delete(string id);
        T GetById(string id);

    }
}
