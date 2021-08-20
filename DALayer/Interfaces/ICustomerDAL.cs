using System.Collections.Generic;


namespace DALayer.Interfaces
{
    public interface ICustomerDAL<T> : IDAL<T>
    {
        List<T> GetCustomerOrdersCost();
        bool CheckIfCustomerExists(int iD);
    }
}
