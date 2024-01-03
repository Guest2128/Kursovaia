using OfficeOpenXml;
using System;
using System.Windows.Forms;

namespace Fill_Table {
    internal static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Application.Run(new Main());
        }
    }
}
