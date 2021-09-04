using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
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
                        fileObj.Ext = Path.GetExtension(fileObj.FilePath);// Path.GetExtension(fileObj.FilePath);
                        fileObj.file = new BinaryReader(stream).ReadBytes((int)stream.Length);
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

        public void OpenFile(string path)
        {
            if (File.Exists(path))
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }

        public bool IsExists(FileEntity v)
        {
            return File.Exists(v.FilePath);
        }
    }
}
