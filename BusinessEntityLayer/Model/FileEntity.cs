
using System;

namespace BusinessEntityLayer.Model
{
    public class FileEntity
    {
        public int OrderId
        { get; set; }
        public int Id
        { get; set; }
        public string Name
        { get; set; }
        public string Ext
        { get; set; }
        public byte[] file
        { get; set;}
        public string FilePath
        { get; set; }
        public override string ToString()
        {
            return String.Format(Name);
        }
    }
}
