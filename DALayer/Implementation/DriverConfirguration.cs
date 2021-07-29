using DALayer.Utils;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace DALayer.Implementation
{
    static class DriverConfirguration
    {

        //reads xml file and returns as data source
        public static DataSet ReadXML()
        {
            DataSet ds = new();
            try
            {
                ds.ReadXml(Constants.FilePath);
            }
            catch (FileNotFoundException exc)
            {
                Debug.WriteLine("Error reading files", exc);
            }
            return ds;
        }

        //saves dataset to xml file
        public static void SaveChanges(DataSet ds)
        {
            try
            {
                ds.WriteXml(Constants.FilePath);
            }
            catch (FileNotFoundException exc)
            {
                Debug.WriteLine("Error reading files", exc);
            }
        }
    }
}
