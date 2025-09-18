namespace TestSpreadsheet
{
    public class RegisterService
    {
        const string EXCEL_PROG_ID = "FalconMatrix.2025";
        const string EXCEL_DESCRIPTION = "Falcon Matrix Spreadsheet File";
        public static bool CheckIfExcelIsInstalled() => 
            Win32RegisterHelper.IsExtensionRegistered("xlsx") &&
            Win32RegisterHelper.IsExtensionRegistered("xls");

        public static void RegisterExcelAssociationToApp()
        {
            Win32RegisterHelper.RegisterFileAssociation(
                "xlsx", EXCEL_PROG_ID, EXCEL_DESCRIPTION, 
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            Win32RegisterHelper.RegisterFileAssociation(
                "xls", EXCEL_PROG_ID, EXCEL_DESCRIPTION,
                System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}