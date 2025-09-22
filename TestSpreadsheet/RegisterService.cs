using System.Diagnostics;

namespace TestSpreadsheet
{
    public class RegisterService
    {
        const string EXCEL_PROG_ID = "FalconMatrix.2025";
        const string EXCEL_DESCRIPTION = "Falcon Matrix Spreadsheet File";
        public static bool CheckIfExcelIsInstalled() => 
            Win32RegistryHelper.IsExtensionRegistered(ExcelFileExtensions.XLS) &&
            Win32RegistryHelper.IsExtensionRegistered(ExcelFileExtensions.XLSX);

        public static void RegisterExcelAssociationToApp()
        {
            var exepath = Process.GetCurrentProcess().MainModule?.FileName ?? default!;
            Win32RegistryHelper.RegisterFileAssociation(
                ExcelFileExtensions.XLS, EXCEL_PROG_ID, EXCEL_DESCRIPTION, exepath);
            Win32RegistryHelper.RegisterFileAssociation(
                ExcelFileExtensions.XLSX, EXCEL_PROG_ID, EXCEL_DESCRIPTION, exepath);
        }
    }
}