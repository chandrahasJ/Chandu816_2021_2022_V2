using NPOI.HSSF.UserModel;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace NSEDataExtractor.HelperFiles
{
    public class ExcelHelper : IDisposable
    {
        private string fileName = null; //file name
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// Import DataTable data into excel
        /// </summary>
        /// <param name="data">Data to be imported</param>
        /// <param name="isColumnWritten">The column name of the DataTable to import or not</param>
        /// <param name="sheetName">The name of the excel sheet to import</param>
        /// <returns>the number of rows of data to import (the row containing the column name)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // v-2007
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // v-2003
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //Write the column names to the DataTable
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs,false); //write to the excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Import DataTable data into excel
        /// </summary>
        /// <param name="data">Data to be imported</param>
        /// <param name="isColumnWritten">The column name of the DataTable to import or not</param>
        /// <param name="sheetName">The name of the excel sheet to import</param>
        /// <returns>the number of rows of data to import (the row containing the column name)</returns>
        public int DataTablesToExcel(Dictionary<string, DataTable> dicSheetName_DataTable, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // v-2007
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // v-2003
                workbook = new HSSFWorkbook();

            try
            {
                foreach (var key in dicSheetName_DataTable.Keys)
                {
                    if (workbook != null)
                    {
                        sheet = workbook.CreateSheet(key);
                    }
                    else
                    {
                        return -1;
                    }

                    var data = dicSheetName_DataTable[key];

                    if (isColumnWritten == true) //Write the column names to the DataTable
                    {
                        IRow row = sheet.CreateRow(0);                      
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                        }
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                    }

                    for (i = 0; i < data.Rows.Count; ++i)
                    {
                        IRow row = sheet.CreateRow(count);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                        ++count;
                    }                                   
                }
                workbook.Write(fs, false); //write to the excel   
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }


        /// <summary>
        /// Import data from excel to DataTable
        /// </summary>
        /// <param name="sheetName">The name of the excel workbook sheet</param>
        /// <param name="isFirstRowColumn">whether the first row is the column name of the DataTable</param>
        /// <returns>returnedDataTable</returns>
        public Dictionary<int, string> ReturnSheetList()
        {
            Dictionary<int, string> t = new Dictionary<int, string>();
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003
                    workbook = new HSSFWorkbook(fs);
                int count = workbook.NumberOfSheets; //get all SheetName
                for (int i = 0; i < count; i++)
                {
                    sheet = workbook.GetSheetAt(i);
                    if (sheet.LastRowNum > 0)
                    {
                        t.Add(i, workbook.GetSheetAt(i).SheetName);
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }　　　

        //index excel
        public DataTable ExcelToDataTable(int index)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003
                    workbook = new HSSFWorkbook(fs);
                //int coutnts = workbook.NumberOfSheets;

                sheet = workbook.GetSheetAt(index);
                //string names= sheet.SheetName;
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //The number of the last cell in a row is the total number of columns


                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        ICell cell = firstRow.GetCell(i);
                        CellType c = cell.CellType;
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }
                    startRow = sheet.FirstRowNum + 1;


                    //The last column of the marker
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //Rows with no data are null by default　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) // Similarly, cells with no data are null by default
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
    }
}
