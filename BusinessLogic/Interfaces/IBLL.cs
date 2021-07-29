using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IBLL<T>
    {
            public List<T> GetAll();
            public List<T> GetOneByName(string name);
            public bool InsertOne(T obj);
            public bool UpdateOne(T obj);
            public bool DeleteOne(T obj);
    }
}
