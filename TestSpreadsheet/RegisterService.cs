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
            Win32RegistryHelper.RegisterFileAssociation(
                "xlsx", EXCEL_PROG_ID, EXCEL_DESCRIPTION, 
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            Win32RegistryHelper.RegisterFileAssociation(
                "xls", EXCEL_PROG_ID, EXCEL_DESCRIPTION,
                System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}