using System.Collections.Generic;

namespace DALayer.Interfaces
{
    public interface IDAL<T>
    {
        List<T> GetAll();
        List<T> GetAllByKeyWord(string name);
        bool UpdateOne(T obj);
        bool InsertOne(T obj);
        bool DeleteOne(int Id);
        List<T> SortByColumnAscending();
        List<T> SortByColumnDescending();
    }
}