
namespace BusinessLogic.Interfaces
{
        public abstract class IImportFeature<T>
        {
            public abstract T ConvertExcelToObject(string FilePath);
            public abstract T ConvertTextFileToObject(string FilePath);
            public abstract T ConvertClipboardDataToObject(string Data);
        }
}
