using System.IO;
using System.Data;
using DALayer.Utils;
using System;

namespace DALayer.Implementation
{
    static class DriverConfirguration
    {
        private static DataSet ds;
        
        //reads xml file and returns as data source
        public static DataSet ReadXML()
        {
            try
            {
                if (ds == null)
                {
                    ds = new DataSet();
                    ds.ReadXml(Constants.FilePath);
                }
               
            }catch(IOException exc)
            {
                Console.WriteLine("Error reading files", exc);
            }
            return ds;
        }

        public static void SaveChanges(DataSet ds1)
        {
            ds1.WriteXml(Constants.FilePath);
        }
    }
}
