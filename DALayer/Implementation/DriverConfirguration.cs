using System.IO;
using System.Data;
using DALayer.Utils;
using System.Diagnostics;

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

            }
            catch (IOException exc)
            {
                Debug.WriteLine("Error reading files", exc);
            }
            return ds;
        }

        //saves dataset to xml file
        public static void SaveChanges(DataSet ds1)
        {
            try
            {
                ds1.WriteXml(Constants.FilePath);
            }
            catch (IOException exc)
            {
                Debug.WriteLine("Error reading files", exc);
            }
        }
    }
}
