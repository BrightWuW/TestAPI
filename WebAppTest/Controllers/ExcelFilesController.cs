using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class ExcelFilesController : Controller
    {
        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ActionResult excelFilesList(List<ExportBankZHDto> list)
        {
            string fileName = "文件名称.xsl";
            var table = new DataTable("TelWorkRecordTable");
            DataColumn column = null;
            DataRow row;
            BuildDataTableColumns(table, column);
            foreach (var item in list)
            {
                row = table.NewRow();
                row["WorkOrderNo"] = item.WorkOrderNo;
                row["AccountNumber"] = item.AccountNumber;
                row["CustName"] = item.CustName;
                row["TelRelation"] = item.TelRelation;
                row["FixedNumber"] = item.FixedNumber;
                row["CallBackResultsName"] = item.CallBackResultsName;
                row["CallBackTime"] = item.CallBackTime == null ? "" : Convert.ToDateTime(item.CallBackTime).ToString("yyyy-MM-dd");
                row["ConcreteContent"] = item.ConcreteContent;
                row["Remarks"] = item.Remarks;
                table.Rows.Add(row);
            }
            
            #region 方法一
            //生成工作表
            MemoryStream ms = NPOIHelper.ConvertDataTableToExcelStream(table);
            ms.Seek(0, SeekOrigin.Begin);
            int index = fileName.IndexOf('.');
            fileName = "ExportBank"; //fileName.Substring(0, index);
            return File(ms, "application/ms-excel", fileName + ".csv");
            #endregion

            #region 方法二
            //ExcelOperate.CreateExcel(table, "ExportBank.xls");
            //return new EmptyResult();
            #endregion
        }

        static void BuildDataTableColumns(DataTable table, DataColumn column)
        {

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "WorkOrderNo";
            column.Caption = "工单编号";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "AccountNumber";
            column.Caption = "账户号";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CustName";
            column.Caption = "客户姓名";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TelRelation";
            column.Caption = "回电客户（关系）";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FixedNumber";
            column.Caption = "固定号码";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CallBackResultsName";
            column.Caption = "回电结果";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CallBackTime";
            column.Caption = "回电时间";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ConcreteContent";
            column.Caption = "具体内容";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Remarks";
            column.Caption = "备注（客服添加此列）";
            table.Columns.Add(column);
        }

    }
    public class NPOIHelper
    {
        public static MemoryStream ConvertDataTableToExcelStream(DataTable data)
        {
            MemoryStream ms = new MemoryStream();
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();
            using (data)
            {

                IRow headerRow = sheet.CreateRow(0);

                foreach (DataColumn column in data.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

                int rowIndex = 1;

                foreach (DataRow row in data.Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in data.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }

                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

            }
            return ms;
        }

    }

    public class ExcelOperate
    {
        ///   <summary>   
        ///   把DataTable转化为xls   
        ///   </summary>   
        [AllowAnonymous]
        public static void CreateExcel(DataTable dt, string FileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpContext.Current.Server.UrlEncode(FileName));
            //定义表对象与行对象，同时用DataSet对其值进行初始化 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int cl = dt.Columns.Count;
            StringBuilder line = new StringBuilder();
            string NumberAsTextExp = "vnd.ms-excel.numberformat:@";
            string DateAsTextExp = "vnd.ms-excel.numberformat:yyyy-mm-dd";
            string s;
            line.Append("<table border = 1><tr>");

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (int i = 0; i < cl; i++)
            {
                line.Append("<td style='" + NumberAsTextExp + "'>");
                s = HttpContext.Current.Server.HtmlEncode(dt.Columns[i].Caption.ToString());
                line.Append(s + "</td>");
            }
            line.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)  //dtTable 是要导出的DataTable
            {
                line.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].DataType == typeof(DateTime))
                    {
                        line.Append("<td style='" + DateAsTextExp + "'>"); //日期型
                    }
                    else if (dt.Columns[j].DataType == typeof(decimal))
                    {
                        line.Append("<td >");
                    }
                    else
                    {
                        line.Append("<td style='" + NumberAsTextExp + "'>"); //将数字按字符串格式导出，比如身份证号码
                    }
                    s = dt.Rows[i][j].ToString();
                    if (dt.Columns[j].DataType == typeof(DateTime))
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if ((Convert.ToDateTime(s)).ToString("yyyy-MM-dd") == "1900-01-01")
                            {
                                s = HttpContext.Current.Server.HtmlEncode("");
                            }
                        }
                    }
                    if (dt.Columns[j].DataType == typeof(string))
                    {
                        s = HttpContext.Current.Server.HtmlEncode(s);
                    }
                    line.Append(s + "</td>");
                }
                line.Append("</tr>");
            }
            line.Append("</table>");
            HttpContext.Current.Response.Write(@"<html><head>");
            HttpContext.Current.Response.Write(@"<meta http-equiv="" content-type="" content=""text/html;  charset=utf-8"">"); //content=""text/html;
            HttpContext.Current.Response.Write("</head>");
            HttpContext.Current.Response.Write("<body>");
            HttpContext.Current.Response.Write(line.ToString());
            HttpContext.Current.Response.Write("</body>");
            HttpContext.Current.Response.Write(@"</html>");

            HttpContext.Current.Response.End();

        }
    }


}