using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;


namespace Cetecean
{
    class LoadExcelFiles
    {

         private const string DefaultACEDbVersion = "12.0";
         private const string DefaultExcelVersion = "12.0";
         private OleDbConnection connection;
         private const string ProviderString = "Provider=Microsoft.ACE.OLEDB.{0};Data Source={1};Extended Properties=\"Excel {2}{3};HDR={3};IMEX=1\";";

        public LoadExcelFiles(string sourceFile)
        {

            if (!File.Exists(sourceFile))
                {
                 throw new FileNotFoundException(
                 String.Format("The source file: {0} can not be found.", sourceFile));
                 }

 



            //try
            //{
            //    xlApp = new Microsoft.Office.Interop.Excel.Application();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Excel is not installed");
            //    return;
            //}
        


            //Excel.Workbook excelWorkbook = xlApp.Workbooks.Open(@path, 0, false, 5,
            //"", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            
            //Excel.Workbooks books = xlApp.Workbooks;
            //Excel.Sheets listSheets = books.Item[0].Worksheets;
            //Excel.Range range;
            //foreach( Excel.Worksheet sheet in listSheets)
            //{
            //    range=sheet.get_Range("A1");
            //    string latitud  = GetFieldPosition(sheet, "Latitude");
            //    string longitud = GetFieldPosition(sheet, "Longitude");

            //    if (latitud != null && longitud != null)
            //    {
            //        MessageBox.Show("hola");
            //    }

            //}

        }

        //public string GetFieldPosition(Excel.Worksheet sheet,string field) {
        //    string pos=null;
        //    for (int i = 0; i < 10; i++) {
        //        string value = (string)sheet.get_Range(Convert.ToChar(65+i) + "1", Missing.Value).get_Value();
        //        if (value.ToUpper() == field.ToUpper())
        //        {
        //            pos = Convert.ToChar(65 + i) + "1";
        //        }
        //    }

        // return pos;
        //}

    }
}
