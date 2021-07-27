using BusinessEntityLayer.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DALayer.Interfaces;

namespace DALayer.Implementation
{
    public class CustomerDAL : IDAL
    {

        List<Customer> customerList;
        DataSet ds = DriverConfirguration.ReadXML();

        public List<Customer> GetAll()
        {
            customerList = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new Customer
                            {
                                Id = int.Parse(dataRow.Field<string>("id")),
                                CustomerName = dataRow.Field<string>("Customer"),
                                ContactName = dataRow.Field<string>("Contact_Name"),
                                Phone = dataRow.Field<string>("Phone"),
                            }).ToList();
            return customerList;
        }

        public List<Customer> GetOneByName(string name)
        {
            customerList = ds.Tables[0].AsEnumerable()
            .Where(r => r.Field<string>("Customer").Contains(name)).Select(dataRow => new Customer
            {
                Id = int.Parse(dataRow.Field<string>("id")),
                CustomerName = dataRow.Field<string>("Customer"),
                ContactName = dataRow.Field<string>("Contact_Name"),
                Phone = dataRow.Field<string>("Phone"),
            }).ToList();

            return customerList;
        }

        public bool UpdateOne(Customer customer)
        {

            if (customer.CustomerName.Length > 0)
            {
                DataRow dr = ds.Tables[0].AsEnumerable()
                    .Where(r => r.Field<string>("id").Equals(customer.Id.ToString())).First();
                dr["Customer"] = customer.CustomerName;
                dr["Contact_Name"] = customer.ContactName;
                dr["Phone"] = customer.Phone;
                ds.Tables[0].AcceptChanges();
                DriverConfirguration.SaveChanges(ds);
                return true;
            }
            return false;
        }

        public bool InsertOne(Customer customer)
        {
            if (customer.CustomerName.Length > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["id"] = customer.Id.ToString();
                dr["Customer"] = customer.CustomerName;
                dr["Contact_Name"] = customer.ContactName;
                dr["Phone"] = customer.Phone;
                ds.Tables[0].Rows.Add(dr);
                ds.Tables[0].AcceptChanges();
                DriverConfirguration.SaveChanges(ds);
                return true;
            }
            return false;
        }

        public bool DeleteOne(Customer customer)
        {
            var dr = (from row in ds.Tables[0].AsEnumerable()
                      where row.Field<string>("id").Equals(customer.Id.ToString())
                      select row).First();
            if (dr != null)
            {
                ds.Tables[0].Rows.Remove(dr);
                ds.Tables[0].AcceptChanges();
                DriverConfirguration.SaveChanges(ds);
                return true;
            }
            return false;
        }
    }
}
