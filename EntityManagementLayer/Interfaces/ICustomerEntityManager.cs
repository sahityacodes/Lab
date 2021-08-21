using System.Collections.Generic;

namespace EntityManagementLayer.Interfaces
{
    public interface ICustomerEntityManager<T> : IEntityManager<T>
    {
        List<T> GetCustomerOrdersCost();
        bool CheckIfCustomerExists(int iD);
    }
}
