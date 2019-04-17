using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.XSSF.Model;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Util
{
    public static class NpoiHelper
    {
        public const string DefaultDateFormat = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 创建Excel处理器
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="action">处理器</param>
        /// <returns>是否创建Excel成功</returns>
        public static bool CreateExcelHandle(string path, Action<IWorkbook> action)
        {
            IWorkbook workbook = null;
            string extension = path.Substring(path.LastIndexOf('.') + 1);
            if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("请指定一个文件类型为Excel的文件路径");
            }
            using (FileStream filestream = new FileStream(path, FileMode.Create))
            {
                action(workbook);
                workbook.Write(filestream);
                workbook.Close();
                filestream.Close();
                filestream.Dispose();
            }
            return true;
        }
        public static bool CreateExcel(string path, DataTable table, List<string> columns, string sheetName)
        {
            return true;
        }
        /// <summary>
        /// 根据DataTable对象和List列对象生成一个Sheet表格
        /// </summary>
        /// <param name="sheet">sheet表格</param>
        /// <param name="table">DataTable对象</param>
        /// <param name="columns">List列对象</param>
        /// <param name="sheetName">sheet的名称</param>
        public static void CreateSheet(IWorkbook workbook, DataTable table, string sheetName)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow columnsRow = sheet.CreateRow(0);
            int length = table.Columns.Count;
            for (int i = 0; i < length; i++)
            {
                string columnsName = table.Columns[i].ColumnName;
                ICell cell = columnsRow.CreateCell(i, CellType.String);
                cell.SetCellValue(columnsName);
                ICellStyle cellStyle = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 20;
                cellStyle.SetFont(font);
                cellStyle.Alignment = HorizontalAlignment.Center;
                cellStyle.VerticalAlignment = VerticalAlignment.Center;
                cell.CellStyle = cellStyle;
                int hopeLength = columnsName.Length + 2;
                if (sheet.GetColumnWidth(i) < hopeLength * 256 * 3 && hopeLength > 3)
                    sheet.SetColumnWidth(i, (((hopeLength * 256 * 3) > 12800) ? 12800 : (hopeLength * 256 * 3)));
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < length; j++)
                {
                    string cellString = table.Rows[i][j].ToString();
                    ICell cell = row.CreateCell(j, CellType.String);
                    string cellValueByString = table.Rows[i][j].ToString();
                    double cellValueByDouble = 0;
                    if (double.TryParse(cellValueByString, out cellValueByDouble))
                    {
                        cell.SetCellValue(cellValueByDouble);
                    }
                    else
                    {
                        cell.SetCellValue(cellValueByString);
                    }
                    //ICellStyle cellStyle = workbook.CreateCellStyle();
                    //cellStyle.Alignment = HorizontalAlignment.Center;
                    //cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    //cell.CellStyle = cellStyle;
                    int hopeLength = cellString.Length + 2;
                    if (sheet.GetColumnWidth(j) < hopeLength * 256 && hopeLength > 3)
                        sheet.SetColumnWidth(j, (((hopeLength * 256) > 12800) ? 12800 : (hopeLength * 256)));
                }
            }
        }
        #region 进阶操作
        /// <summary>
        /// 自动添加行
        /// </summary>
        /// <param name="workbook">工作表</param>
        /// <param name="json">自动JSON</param>
        public static void DiyExcelByJavaScript(string path, string json, string newPath = "")
        {
            JArray arr = JsonConvert.DeserializeObject<JArray>(json);
            if (newPath == "") { newPath = path; }
            NpoiHelper.GetWorkbookHandle(path, (workbook) =>
            {
                foreach (JObject obj in arr)
                {
                    ISheet sheet = null;
                    int sheetIndex = 0;
                    string sheetName = obj["sheet"].IfEmpty("0");
                    if (int.TryParse(sheetName, out sheetIndex))
                    {
                        sheet = workbook.GetSheetAt(sheetIndex);
                    }
                    else
                    {
                        sheet = workbook.GetSheet(sheetName);
                    }
                    if (sheet != null)
                    {
                        sheet.ForceFormulaRecalculation = true;
                        string type = ((obj["type"] == null) ? "insert" : obj["type"].ToString());
                        int at = ((obj["at"] == null) ? sheet.LastRowNum : Convert.ToInt32(obj["at"].ToString()));
                        if (type == "insert")
                        {
                            InsertAt(sheet, at, obj["rows"]);
                        }
                        if (type == "update")
                        {
                            UpdateAt(sheet, at, obj["rows"]);
                        }
                        if (type == "replace")
                        {
                            ReplaceString(sheet, obj["data"] as JArray);
                        }
                    }
                }
            }, newPath);
        }
        public static void UpdateAt(ISheet sheet, int rowIndex, IEnumerable rowData)
        {
            foreach (IEnumerable arr in rowData)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    int cellIndex = 0;
                    foreach (object item in arr)
                    {
                        string cellString = item.ToString();
                        if (cellString != "$formula$")
                        {
                            ICell cell = row.GetCell(cellIndex);
                            if (cell == null)
                            {
                                cell = row.CreateCell(cellIndex, CellType.String);
                                cell.SetCellValue(cellString);
                            }
                            double numeric = 0.0;
                            if (double.TryParse(cellString, out numeric))
                            {
                                cell.SetCellType(CellType.Numeric);
                                cell.SetCellValue(numeric);
                            }
                            else
                            {
                                cell.SetCellType(CellType.String);
                                cell.SetCellValue(cellString);
                            }
                        }
                        cellIndex++;
                    }
                }
                rowIndex++;
            }
        }
        public static void InsertAt(ISheet sheet, int rowIndex, IEnumerable rowData)
        {
            foreach (IEnumerable arr in rowData)
            {
                rowIndex = rowIndex > sheet.LastRowNum ? sheet.LastRowNum : rowIndex;
                IRow row = null;
                if (rowIndex != sheet.LastRowNum)
                {
                    sheet.ShiftRows(rowIndex, sheet.LastRowNum, 1);
                    row = sheet.CreateRow(rowIndex);
                }
                else
                {
                    row = sheet.CreateRow(++rowIndex);
                }
                int cellIndex = 0;
                foreach (object cell in arr)
                {
                    string cellString = cell.ToString();
                    double cellDouble = 0;
                    if (double.TryParse(cellString, out cellDouble))
                    {
                        row.CreateCell(cellIndex, CellType.Numeric).SetCellValue(cellDouble);
                    }
                    else
                    {
                        row.CreateCell(cellIndex, CellType.String).SetCellValue(cellString);
                    }
                    cellIndex++;
                }
                rowIndex++;
            }
        }
        public static void ReplaceString(ISheet sheet, JArray arr)
        {
            for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                for (int j = row.FirstCellNum; j <= row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell != null)
                    {
                        if (cell.CellType == CellType.String)
                        {
                            foreach (var obj in arr)
                            {
                                cell.SetCellValue(cell.StringCellValue.Replace(obj["o"].ToString(), obj["n"].ToString()));
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 读取相关
        public static IWorkbook GetWorkbook(FileStream fs, string path)
        {
            if (new FileInfo(path).Extension == ".xls")
            {
                return new HSSFWorkbook(fs);
            }
            if (new FileInfo(path).Extension == ".xlsx")
            {
                return new XSSFWorkbook(fs);
            }
            return null;
        }
        public static void GetWorkbookHandle(string path, Action<IWorkbook> action, string newPath = "")
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                // LogHelper.WriteLog("开始读取xlsx");
                IWorkbook workbook = null;
                if (new FileInfo(path).Extension == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                if (new FileInfo(path).Extension == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                // LogHelper.WriteLog("读取xlsx结束");
                if (newPath == "") { newPath = path; }
                using (FileStream filestream = new FileStream(newPath, FileMode.Create))
                {
                    action(workbook);
                    workbook.Write(filestream);
                    workbook.Close();
                    filestream.Close();
                    filestream.Dispose();
                }
            }
        }
        public static void GetSheetsHandle(string path, Action<ISheet> action)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                IWorkbook workbook = NpoiHelper.GetWorkbook(fs, path);
                int sheetlength = workbook.NumberOfSheets;
                for (int i = 0; i < sheetlength; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    action(sheet);
                }
            }
        }
        public static ISheet GetSheet(string path, int index)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                return GetWorkbook(fs, path).GetSheetAt(index);
            }
        }
        public static ISheet GetSheet(string path, string sheetName)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                return GetWorkbook(fs, path).GetSheet(sheetName);
            }
        }
        public static String GetCellString(ICell cell, string dateFormat = DefaultDateFormat)
        {
            if (cell == null) { return ""; }
            CellType cellType = cell.CellType;
            if (cellType == CellType.String)
                return cell.StringCellValue;
            else if (cellType == CellType.Numeric)
            {
                if (HSSFDateUtil.IsCellDateFormatted(cell))
                {
                    return cell.DateCellValue.ToString(dateFormat);
                }
                else
                {
                    return cell.NumericCellValue.ToString();
                }
            }
            else if (cellType == CellType.Formula)
            {
                string formulaStr = "";
                try
                {
                    DateTime date = cell.DateCellValue;
                    var a = HSSFDateUtil.IsCellDateFormatted(cell);
                    if (date == DateTime.MinValue || !a)
                    {
                        formulaStr = cell.NumericCellValue.ToString();
                    }
                    else
                    {
                        formulaStr = cell.DateCellValue.ToString(dateFormat);
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        formulaStr = cell.NumericCellValue.ToString();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            formulaStr = cell.StringCellValue.ToString();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                return formulaStr;
            }
            else if (cellType == CellType.Blank)
            {
                return "";
            }
            else
                throw new Exception("Excel中包含未知的单元格类型：" + cellType.ToString() + "另外，请注意字段行必须为字符串");
        }
        public static String GetCellString(ISheet sheet, int row, int col, string dateFormat = DefaultDateFormat)
        {
            return GetCellString(sheet.GetRow(row).GetCell(col), dateFormat);
        }
        public static DataTable GetTable(string path, int sheetIndex = 0, int startRow = -1, int lastRow = -1, bool getColumnName = true, string dateFormat = DefaultDateFormat)
        {
            ISheet sheet = GetSheet(path, sheetIndex);
            return GetTable(sheet, dateFormat, startRow, lastRow, getColumnName);
        }
        public static DataTable[] GetTable(string path, int sheetIndex, bool getColumnName, string dateFormat, Func<ISheet, String, int[]> getFirstRowIndex)
        {
            ISheet sheet = GetSheet(path, sheetIndex);
            if (dateFormat == null || dateFormat.Trim() == "") { dateFormat = DefaultDateFormat; }
            int[] arg = getFirstRowIndex(sheet, dateFormat);
            DataTable[] tables = new DataTable[arg.Length / 2];
            for (int i = 0, j = 0; i < tables.Length; i++, j++)
            {
                tables[i] = GetTable(sheet, dateFormat, arg[j], arg[++j], getColumnName);
            }
            return tables;
        }
        public static DataTable GetTableByName(string path, string sheetName = "Sheet1", int startRow = -1, int lastRow = -1, bool getColumnName = true, string dateFormat = DefaultDateFormat)
        {
            ISheet sheet = GetSheet(path, sheetName);
            return GetTable(sheet, dateFormat, startRow, lastRow, getColumnName);
        }
        public static DataTable[] GetTableByName(string path, string sheetName, bool getColumnName, string dateFormat, Func<ISheet, String, int[]> getFirstRowIndex)
        {
            ISheet sheet = GetSheet(path, sheetName);
            if (dateFormat == null || dateFormat.Trim() == "") { dateFormat = DefaultDateFormat; }
            int[] arg = getFirstRowIndex(sheet, dateFormat);
            DataTable[] tables = new DataTable[arg.Length / 2];
            for (int i = 0, j = 0; i < tables.Length; i++, j++)
            {
                tables[i] = GetTable(sheet, dateFormat, arg[j], arg[++j], getColumnName);
            }
            return tables;
        }
        public static DataTable GetTable(ISheet sheet, string dateFormat, int startRow, int lastRow, bool getColumnName)
        {
            DataTable table = new DataTable();
            int startRowIndex = startRow <= 0 ? sheet.FirstRowNum : startRow, endRowIndex = lastRow == -1 ? sheet.LastRowNum : lastRow;
            bool col = true;
            for (int r = startRowIndex; r <= endRowIndex; r++)
            {
                if (sheet.GetRow(r) == null) continue;
                int startCellIndex = 0, endCellIndex = sheet.GetRow(r).LastCellNum;
                DataRow row = table.NewRow();
                for (int c = startCellIndex; c < (col ? (endCellIndex) : (Math.Min(endCellIndex, table.Columns.Count))); c++)
                {
                    string cellString = GetCellString(sheet.GetRow(r).GetCell(c), dateFormat);
                    if (col)
                    {
                        Console.WriteLine(getColumnName ? cellString : (c + 1).ToString());
                    }
                    if (col)
                        table.Columns.Add(getColumnName ? cellString : (c + 1).ToString());
                    else
                        row[c] = cellString;
                }
                if (!col)
                {
                    table.Rows.Add(row);
                }
                col = false;
            }
            table.TableName = sheet.SheetName;
            return table;
        }
        #endregion
    }
}
