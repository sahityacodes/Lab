using BusinessEntityLayer.Model;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic.Implementation.FileOperationsLogic
{
    public class FileOperationsImpl
    {
        public void SaveFile(FileEntity fileObj)
        {
            Stream stream = new FileStream(fileObj.FilePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(stream);
            foreach (var b in fileObj.file)
            {
                bw.Write(b);
            }
            bw.Flush();
            bw.Close();
        }

        public List<FileEntity> ConvertFileToBinary(List<FileEntity> obj)
        {
            List<FileEntity> newList = new();
            foreach (FileEntity fileObj in obj)
            {
                if(fileObj.FilePath != null && fileObj.file == null)
                {
                    try
                    {
                        FileStream stream = new FileStream(fileObj.FilePath, FileMode.Open, FileAccess.Read);
                        fileObj.file = new BinaryReader(stream).ReadBytes((int)stream.Length);
                        fileObj.Ext = Path.GetExtension(fileObj.FilePath);// Path.GetExtension(fileObj.FilePath);
                        fileObj.Name = Path.GetFileNameWithoutExtension(fileObj.FilePath);
                    }
                    catch (FileNotFoundException)
                    {
                    }
                }
                if (fileObj.file != null) newList.Add(fileObj);
            }
            return newList;
        }
    }
}
