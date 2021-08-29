
namespace BusinessLogic.Implementation.OrderLogic
{
    public interface IImportFeature<T>
    {
        public T ConvertExcelToObject(string FilePath);
        public T ConvertTextFileToObject(string FilePath);
        public T ConvertClipboardDataToObject(string Data);
    }
}
