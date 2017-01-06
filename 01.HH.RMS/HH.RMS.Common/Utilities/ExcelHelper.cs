using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HH.RMS.Common.Utilities
{
    public class ExcelHelper
    {
        public static void Export(Stream stream, DataSet dataSet)
        {
            DataTableCollection tables = dataSet.Tables;
            using (XmlTextWriter x = new XmlTextWriter(stream, Encoding.UTF8))
            {
                int sheetNumber = 0;
                x.WriteRaw("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?>");
                x.WriteRaw("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
                x.WriteRaw("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
                x.WriteRaw("xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                x.WriteRaw("<Styles><Style ss:ID='sText'>" +
                           "<NumberFormat ss:Format='@'/></Style>");
                x.WriteRaw("<Style ss:ID='sDate'><NumberFormat" +
                           " ss:Format='[$-409]m/d/yy\\ h:mm\\ AM/PM;@'/>");
                x.WriteRaw("</Style></Styles>");
                foreach (DataTable dt in tables)
                {
                    sheetNumber++;
                    string sheetName = !string.IsNullOrEmpty(dt.TableName) ?
                           dt.TableName : "Sheet" + sheetNumber.ToString();
                    x.WriteRaw("<Worksheet ss:Name='" + sheetName + "'>");
                    x.WriteRaw("<Table>");
                    string[] columnTypes = new string[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string colType = dt.Columns[i].DataType.ToString().ToLower();

                        if (colType.Contains("datetime"))
                        {
                            columnTypes[i] = "DateTime";
                            x.WriteRaw("<Column ss:StyleID='sDate'/>");
                        }
                        else if (colType.Contains("string"))
                        {
                            columnTypes[i] = "String";
                            x.WriteRaw("<Column ss:StyleID='sText'/>");
                        }
                        else
                        {
                            x.WriteRaw("<Column />");

                            if (colType.Contains("boolean"))
                            {
                                columnTypes[i] = "Boolean";
                            }
                            else
                            {
                                //default is some kind of number.
                                columnTypes[i] = "Number";
                            }
                        }
                    }
                    //column headers
                    x.WriteRaw("<Row>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        x.WriteRaw("<Cell ss:StyleID='sText'><Data ss:Type='String'>");
                        x.WriteRaw(col.ColumnName);
                        x.WriteRaw("</Data></Cell>");
                    }
                    x.WriteRaw("</Row>");
                    //data
                    bool missedNullColumn = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        x.WriteRaw("<Row>");
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (!row.IsNull(i))
                            {
                                if (missedNullColumn)
                                {
                                    int displayIndex = i + 1;
                                    x.WriteRaw("<Cell ss:Index='" + displayIndex.ToString() +
                                               "'><Data ss:Type='" +
                                               columnTypes[i] + "'>");
                                    missedNullColumn = false;
                                }
                                else
                                {
                                    x.WriteRaw("<Cell><Data ss:Type='" +
                                               columnTypes[i] + "'>");
                                }

                                switch (columnTypes[i])
                                {
                                    case "DateTime":
                                        x.WriteRaw(((DateTime)row[i]).ToString("s"));
                                        break;

                                    case "Boolean":
                                        x.WriteRaw(((bool)row[i]) ? "1" : "0");
                                        break;

                                    case "String":
                                        x.WriteString(row[i].ToString());
                                        break;

                                    default:
                                        x.WriteString(row[i].ToString());
                                        break;
                                }

                                x.WriteRaw("</Data></Cell>");
                            }
                            else
                            {
                                missedNullColumn = true;
                            }
                        }
                        x.WriteRaw("</Row>");
                    }
                    x.WriteRaw("</Table></Worksheet>");
                }
                x.WriteRaw("</Workbook>");
            }
            //Response.End();
        }

        public static IList<T> ExportToList<T>(Stream stream, string[] fields) where T : class,new()
        {
            XSSFWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheetAt(0);
            IList<T> list = new List<T>();

            //遍历每一行数据
            for (int i = 0; i < sheet.PhysicalNumberOfRows; i++)
            {
                T t = new T();
                IRow row = sheet.GetRow(i);

                for (int j = 0; j < fields.Length; j++)
                {
                    ICell cell = row.GetCell(j);
                    object cellValue = null;
                    string propertyType = typeof(T).GetProperty(fields[j]).ToString();

                    if (propertyType.IndexOf("String") > 0)
                    {
                        if (cell == null)
                        {
                            cellValue = "";
                        }
                        else
                        {
                            cellValue = cell.StringCellValue;
                        }
                    }
                    else if (propertyType.IndexOf("Decimal") > 0)
                    {
                        if (cell == null)
                        {
                            cellValue = 0;
                        }
                        else
                        {
                            cellValue = Convert.ToDecimal(cell.NumericCellValue);//转换为Decimal
                        }
                    }
                    else if (propertyType.IndexOf("Int32") > 0) //数值
                    {
                        if (cell == null)
                        {
                            cellValue = 0;
                        }
                        else
                        {
                            cellValue = Convert.ToInt32(cell.NumericCellValue);//转换为Int32
                        }
                    }
                    else if (propertyType.IndexOf("Int64") > 0) //数值
                    {
                        if (cell == null)
                        {
                            cellValue = 0;
                        }
                        else
                        {
                            cellValue = Convert.ToInt64(cell.NumericCellValue);//转换为Int64
                        }
                    }
                    else if (propertyType.IndexOf("Double") > 0) //数值
                    {
                        if (cell == null)
                        {
                            cellValue = 0;
                        }
                        else
                        {
                            cellValue = Convert.ToDouble(cell.NumericCellValue);//转换为Double
                        }
                    }
                    else if (propertyType.IndexOf("DateTime") > 0) //时间
                    {
                        if (cell == null)
                        {
                            cellValue = Convert.ToDateTime("1900-01-01");
                        }
                        else
                        {
                            cellValue = Convert.ToDateTime(cell.NumericCellValue);//转换为时间
                        }
                    }
                    else if (propertyType.IndexOf("Boolean") > 0) //数值
                    {
                        if (cell == null)
                        {
                            cellValue = false;
                        }
                        else
                        {
                            cellValue = cell.BooleanCellValue;//转换为int
                        }
                    }

                    typeof(T).GetProperty(fields[j]).SetValue(t, cellValue, null);
                }
                list.Add(t);
            }

            return list;
        }
    }
}
