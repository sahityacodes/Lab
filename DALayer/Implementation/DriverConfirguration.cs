using System.Data;
using DALayer.Utils;

namespace DALayer.Implementation
{
    static class DriverConfirguration
    {
        private static DataSet ds;
        
        //reads xml file and returns as data source
        public static DataSet ReadXML()
        {
            if (ds == null)
            {
                ds = new DataSet();
                ds.ReadXml(Constants.FilePath);
            }
            return ds;
        }
    }
}
