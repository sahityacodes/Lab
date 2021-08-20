using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IBLL<T>
    {
            public List<T> GetAll();
            public List<T> GetOneByName(string name);
            public T GetOne(int OrderID);
            public bool InsertOne(T obj);
            public bool UpdateOne(T obj);
            public bool DeleteOne(int Id, int rowID);
             public bool DeleteAll(int Id);
             public List<T> SortByColumnAscending(string colName);
            public List<T> SortByColumnDescending(string colName);
    }
}
