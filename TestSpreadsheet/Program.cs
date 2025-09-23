using DevExpress.XtraSpreadsheet;
using System.IO;

namespace TestSpreadsheet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var mainform = new MainForm();
            if (args.Length > 0 && File.Exists(args[0]))
                mainform.OpenFileOnStart = args[0];            
            Application.Run(mainform);
        }
    }
}