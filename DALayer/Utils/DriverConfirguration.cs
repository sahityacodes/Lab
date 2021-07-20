using System.Data;

namespace DALayer
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
