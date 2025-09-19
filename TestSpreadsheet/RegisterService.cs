using System.Diagnostics;
using System.Reflection;

namespace TestSpreadsheet
{
    public class RegisterService
    {
        const string EXCEL_PROG_ID = "FalconMatrix.2025";
        const string EXCEL_DESCRIPTION = "Falcon Matrix Spreadsheet File";
        public static bool CheckIfExcelIsInstalled() => 
            Win32RegistryHelper.IsExtensionRegistered("xlsx") &&
            Win32RegistryHelper.IsExtensionRegistered("xls");

        public static void RegisterExcelAssociationToApp()
        {
            var exepath = Process.GetCurrentProcess().MainModule?.FileName ?? default!;
            Win32RegistryHelper.RegisterFileAssociation(
                "xlsx", EXCEL_PROG_ID, EXCEL_DESCRIPTION, exepath);
            Win32RegistryHelper.RegisterFileAssociation(
                "xls", EXCEL_PROG_ID, EXCEL_DESCRIPTION, exepath);
        }
    }
}