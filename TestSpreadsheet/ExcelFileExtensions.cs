namespace TestSpreadsheet
{
    public class ExcelFileExtensions
    {
        public const string XLSX = ".xlsx";
        public const string XLS = ".xls";
        public static readonly string[] All = [XLSX, XLS];
        public static string GetAllAsString() => string.Join(" and ", All);
    }
}