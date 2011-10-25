﻿
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace Cetecean
{

    /// <summary>
    /// Converts XLS, XLSM, XLSX, XLSB to CSV File.
    /// Multiple sheets can either be appeneded to the same CSV file or saved seperatly.
    /// <para>
    /// </para>
    /// </summary>
    public class ExcelData
    {
        #region Private Fields
        /// <summary>
        /// Gets The default ACE DB Driver Version used; if no override provided
        /// </summary>
        private const string DefaultACEDbVersion = "12.0";

        /// <summary>
        /// Gets The default Excel Version used; if no override provided
        /// </summary>
        private const string DefaultExcelVersion = "12.0";

        /// <summary>
        /// The OLE DB Connection String.
        /// {0}: ACE DB Version. Default '12.0'
        /// {1}: Source File (xls(x/b))
        /// {2}: Excel Version. Default '12.0'
        /// {3}: XML. Empty string for XLS. XLSX/XLSB needs to be ' Xml'.
        /// </summary>
        private const string ProviderString = "Provider=Microsoft.ACE.OLEDB.{0};Data Source={1};Extended Properties=\"Excel {2}{3};HDR={3};IMEX=1\";";

        /// <summary>
        /// The OLE DB Connection to use.
        /// </summary>
        private OleDbConnection connection;

        /// <summary>
        /// IsXML File. Yes for XLSX, XLSB. No for XLS.
        /// </summary>
        private bool isXMLFile;

        /// <summary>
        /// The list of worksheet names in the xls(b/x) file
        /// </summary>
        private List<string> workSheetNames;

        /// <summary>
        /// The data within the XLS file.
        /// </summary>
        private Dictionary<string, DataTable> workSheets;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XLSToCSVConverter"/> class.
        /// </summary>
        /// <param name="sourceFile">
        /// The path to the xls(b/x) being converted
        /// </param>
        /// <param name="importheader">
        /// Option to import the header row or not.
        /// </param>
        /// <param name="saveAs">
        /// The option to save the xls(x/b) as one csv file or a csv file per worksheet.
        /// </param>
        /// <param name="delimeter">
        /// The CSV file delimeter requried.
        /// </param>
        /// <param name="qualifier">
        /// The CSV file qualifier required.
        /// </param>
        public ExcelData(string sourceFile, ImportHeader importheader, SaveAs saveAs, char delimeter, char qualifier)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException(
                String.Format("The source file: {0} can not be found.", sourceFile));
            }

            this.IsSaveAs = saveAs;
            this.SourceFile = sourceFile;
            this.IsImportHeader = importheader;
            this.Delimeter = delimeter.ToString();
            this.Qualifier = qualifier.ToString();
            this.workSheets = new Dictionary<string, DataTable>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XLSToCSVConverter"/> class.
        /// </summary>
        /// <param name="sourceFile">
        /// The path to the xls(b/x) being converted
        /// </param>
        /// <param name="importheader">
        /// Option to import the header row or not.
        /// </param>
        /// <param name="saveAs">
        /// The option to save the xls(x/b) as one csv file or a csv file per worksheet.
        /// </param>
        /// <param name="aceVersion">
        /// The ACE DB Override version. (Default 12.0).
        /// </param>
        /// <param name="excelVersion">
        /// The Excel Override version. (Default 12.0).
        /// </param>
        /// /// <param name="delimeter">
        /// The CSV file delimeter requried.
        /// </param>
        /// <param name="qualifier">
        /// The CSV file qualifier required.
        /// </param>
        public ExcelData(string sourceFile, ImportHeader importheader, SaveAs saveAs, string aceVersion, string excelVersion, char delimeter, char qualifier)
            : this(sourceFile, importheader, saveAs, delimeter, qualifier)
        {
            this.ACEDbVersionOverride = aceVersion;
            this.ExcelVersionOverride = excelVersion;
        }



        public ExcelData(string sourceFile  )
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException(
                String.Format("The source file: {0} can not be found.", sourceFile));
            }

            if (sourceFile.ToUpper().IndexOf("XLSX") < 0) {
                this.isXMLFile = true;
            }

            this.SourceFile = sourceFile;

           this.workSheets = new Dictionary<string, DataTable>();
        }


        #endregion

        #region Enumerators
        /// <summary>
        /// Include the first row of the work sheet.
        /// If a combined CSV file is being created and this is set to yes; only the first worksheet will have the first row included.
        /// </summary>
        public enum ImportHeader
        {
            /// <summary>
            /// Includes the first row
            /// </summary>
            Yes,

            /// <summary>
            /// Does not include the first row
            /// </summary>
            No
        }

        /// <summary>
        /// If a combined CSV file is being created and this is set to yes; only the first worksheet will have the first row included.
        /// </summary>
        public enum SaveAs
        {
            /// <summary>
            /// All work sheets are saved as one combined CSV file
            /// </summary>
            CombinedWorkBook,

            /// <summary>
            /// All work sheets are saved as seperate CSV files.
            /// The filename of each will be target-worksheename.csv
            /// </summary>
            SeperateWorkSheets
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the path to the source file being converted
        /// </summary>
        public string SourceFile { get; private set; }

        /// <summary>
        /// Gets the ImportHeader option. Either include the first row or not.
        /// </summary>
        public ImportHeader IsImportHeader { get; private set; }

        /// <summary>
        /// Gets the SaveAs option. Either one csv file or a seperate csv file per worksheet
        /// </summary>
        public SaveAs IsSaveAs { get; private set; }

        /// <summary>
        /// Gets the overridden ACE DB Version used for connection.
        /// </summary>
        public string ACEDbVersionOverride { get; private set; }

        /// <summary>
        /// Gets the overridden Excel Version used for connection.
        /// </summary>
        public string ExcelVersionOverride { get; private set; }

        /// <summary>
        /// Gets ACE Db Driver Version to use for connection.
        /// </summary>
        public string ACEDbVersion
        {
            get
            {
                return this.ACEDbVersionOverride ?? DefaultACEDbVersion;
            }
        }

        /// <summary>
        /// Gets Excel Version to use for connection
        /// </summary>
        public string ExcelVersion
        {
            get
            {
                return this.ExcelVersionOverride ?? DefaultExcelVersion;
            }
        }

        /// <summary>
        /// Gets XMLConnectionString. Only required for XLS/B files
        /// </summary>
        public string XMLConnectionString
        {
            get
            {
                return this.isXMLFile ? " Xml" : string.Empty;
            }
        }

        /// <summary>
        /// Gets HeaderRowConnectionString. Yes/No depending
        /// upon whther the user wants the first row to be included
        /// int the output
        /// </summary>
        public string HeaderRowConnectionString
        {
            get
            {
                // The connection string asumes you don't want the header and is to be read "Header in file". If yes then the first row is not read.
                return this.IsImportHeader == ImportHeader.Yes ? ImportHeader.No.ToString() : ImportHeader.Yes.ToString();
            }
        }

        /// <summary>
        /// Gets the DB ConnectionString with required parameters.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return
                String.Format(
                "Provider=Microsoft.ACE.OLEDB.{0};Data Source={1};Extended Properties=\"Excel {2}{3};HDR={4};IMEX=1\";",
                this.ACEDbVersion,
                this.SourceFile,
                this.ExcelVersion,
                this.XMLConnectionString,
                this.HeaderRowConnectionString);
            }
        }

        /// <summary>
        /// Gets the CSV file delimeter required.
        /// </summary>
        public string Delimeter { get; private set; }

        /// <summary>
        /// Gets the CSV file qualifier / escape character
        /// </summary>
        public string Qualifier { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// I would remove this before placing in the source code.
        /// </summary>
        /// <param name="args">
        /// CMD line args.
        ///// </param>

        /// <summary>
        /// Converts the XLS(X/B) to csv.
        /// </summary>
        public void Import()
        {
            try
            {
                this.OpenConnection();
                this.SetWorkSheets();
                this.SetDataFromWorkSheets();
                this.CloseConnections();
                
            }
            finally
            {
                this.CloseConnections();
            }
        }

        public DataTable GetData(string type)
        {
          return this.GetDataTable(this.GetListOfDataTables(string.Empty),type);
        }


        #endregion

        #region Private Methods
        /// <summary>
        /// Opens the database connection to the file.
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                this.connection = new OleDbConnection(this.ConnectionString);
               
                this.connection.Open();
            }
            catch
            {
                throw new Exception("There was a problem opening the excel file.");
            }
        }

        /// <summary>
        /// Closes all open streams and database connections.
        /// </summary>
        private void CloseConnections()
        {
            if (this.connection == null)
            {
                return;
            }

            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }

            this.connection.Dispose();
        }

        /// <summary>
        /// Sets the worksheet names.
        /// </summary>
        private void SetWorkSheets()
        {
            this.workSheetNames = new List<string>();

            var workSheetNamesDataTable = this.connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (workSheetNamesDataTable == null)
            {
                return;
            }

            foreach (DataRow workSheet in workSheetNamesDataTable.Rows)
            {
                if (workSheet != null)
                {
                    this.workSheetNames.Add(workSheet["TABLE_NAME"].ToString());
                }
            }
        }

        /// <summary>
        /// Gets the data from the worksheets and places them in HastTable of String and List of String keyed upon the work sheet name
        /// </summary>
        private void SetDataFromWorkSheets()
        {
            foreach (string workSheetName in this.workSheetNames)
            {
                DataTable workSheet = this.GetDataFromWorkSheet(workSheetName);
                this.workSheets.Add(workSheetName, workSheet);
            }
        }

       
        private bool CheckNamesList(string type, string name)
        {
            
            ArrayList pointColumnNames = new ArrayList();
            pointColumnNames.Add("LATITUDE");
            pointColumnNames.Add("LONGITUDE");

            ArrayList trackColumnNames = new ArrayList();
            trackColumnNames.Add("STARTLAT");
            trackColumnNames.Add("STARTLONG");
            trackColumnNames.Add("ENDLAT");
            trackColumnNames.Add("ENDLONG");

            if (type == "point")
            {

                if (pointColumnNames.Contains(name))
                    return true; 
            }
            if (type == "line")
            {
                if (trackColumnNames.Contains(name))
                    return true; 
            }

            return false;
        }

        private DataTable CopyMemory(DataTable table)
        {
            DataTable newTable = new DataTable();

            foreach (DataColumn col in table.Columns)
            {
                newTable.Columns.Add(col.ColumnName, col.DataType);
            }


            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = newTable.NewRow();
                newRow.ItemArray = row.ItemArray;
            }


            return newTable;

            //table.Columns.Add("Latitude", typeof(double));
            //table.Columns.Add("Longitude", typeof(double));
            //table.Rows.Add(45.253, -112.43);
            //table.Rows.Add(45.509, -112.46091);

        }


        private Type FieldType(string name)
        {

            switch (name)
            {
                case "STARTLAT":
                case "ENDLAT":
                case "STARTLON":
                case "ENDLON":
                case "LATITUDE":
                case "LONGITUDE":
                    return typeof(double);
                case "UNIQUE ROW NUMBER":
                case "TRANSECTID":
                case "SEGMENT ID":
                case "LEFT":
                case "RIGHT":
                case "COURSE":
                case "NUMBER":
                case "SIGHTING ID":
                    return typeof(int);
                default:
                    return typeof(string);
            }


        }
         



        private DataTable GetDataTable(IList<DataTable> dataTables, string type) 
        {
            SortedList<string,string> columnNamesCheck = new SortedList<string,string>();

            foreach (DataTable dataTable in dataTables)
            {

                DataRow row = dataTable.Rows[0];
                //foreach (DataRow row in dataTable.Rows)
                //{
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        string columnData = System.Convert.ToString(row[col]);

                        if (CheckNamesList(type, columnData.ToUpper()))
                        {
                            columnNamesCheck.Add(columnData.ToUpper(), columnData);
                        }
                    }
                //}

                    if (columnNamesCheck.Count == 2 || columnNamesCheck.Count == 4 || columnNamesCheck.Count ==5)
                    {
                        DataTable newTable = new DataTable();
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            string columnData = System.Convert.ToString(row[col]);
                            newTable.Columns.Add(columnData, FieldType(columnData.ToUpper()));
                        }

                        int i = 0;
                        foreach (DataRow rowi in dataTable.Rows)
                        {
                            if (i > 0)
                            {
                                DataRow newRow = newTable.NewRow();
                                newRow.ItemArray = rowi.ItemArray;
                                newTable.Rows.Add(newRow);
                            }
                            i++;
                        }

                        return newTable;
                    }
            }

            return null;
        
        
        }


        /// <summary>
        /// It might seem a little pointless but it makes WriteCSVFiles cleaner to code.
        /// </summary>
        /// <param name="workSheetName">
        /// The work sheet name to return; otherwise all work sheets data tables are added into the list
        /// </param>
        /// <returns>
        /// A list of the required datasheet or all datasheets
        /// </returns>
        private List<DataTable> GetListOfDataTables(string workSheetName)
        {
            var dataTables = new List<DataTable>();

            if (workSheetName != string.Empty)
            {
                dataTables.Add(this.workSheets[workSheetName]);
            }
            else
            {
                foreach (KeyValuePair<string, DataTable> dataTable in this.workSheets)
                {
                    dataTables.Add(dataTable.Value);
                }
            }

            return dataTables;
        }

        /// <summary>
        /// Populates a DataSet with all data within a workshee.
        /// </summary>
        /// <param name="workSheetName">
        /// The work sheet name.
        /// </param>
        /// <returns>
        /// A DataSet with the data for the worksheet
        /// </returns>
        private DataTable GetDataFromWorkSheet(string workSheetName)
        {
            var selectString = String.Format("SELECT * FROM [{0}]", workSheetName);

            OleDbCommand command = null;
            OleDbDataAdapter dataAdapter = null;

            try
            {
                command = new OleDbCommand(selectString, this.connection) { CommandType = CommandType.Text };
                dataAdapter = new OleDbDataAdapter(command);

                var workSheetData = new DataTable();
                dataAdapter.Fill(workSheetData);
                return workSheetData;
            }
            finally
            {
                if (dataAdapter != null)
                {
                    dataAdapter.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }
        }

        #endregion
    }
}