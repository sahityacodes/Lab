using System.Collections.Generic;

namespace DALayer.Interfaces
{
    public interface IDAL<T>
    {
        List<T> GetAll();
        T GetOne(int OrderID);
        List<T> GetAllByKeyWord(string name);
        bool UpdateOne(T obj);
        bool InsertOne(T obj);
        bool DeleteAll(int Id);
        bool DeleteOne(int Id, int rowID);
        List<T> SortByColumnAscending(string ColName);
        List<T> SortByColumnDescending(string ColName);
        
    }
}