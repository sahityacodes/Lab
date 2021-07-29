using System.Collections.Generic;

namespace DALayer.Interfaces
{
    public interface IDAL<T>
    {
        List<T> GetAll();
        List<T> GetOneByName(string name);
        bool UpdateOne(T obj);
        bool InsertOne(T obj);
        bool DeleteOne(T obj);
    }
}