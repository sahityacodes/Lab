
namespace BusinessLogic.Interfaces
{
        public interface IImportFeature<T>
        {
            public T ConvertExcelToObject(string FilePath);
            public T ConvertTextFileToObject(string FilePath);
            public T ConvertClipboardDataToObject(string Data);
        }
}
