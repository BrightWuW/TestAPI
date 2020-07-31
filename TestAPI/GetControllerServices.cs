using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace TestAPI
{
    public class GetControllerServices
    {
        public static void GetGetControllerServicesList()
        {
            Console.WriteLine("开始遍历目录...");

            string rootPath = @"D:\WorkBao\XiangMuBao\OscarSystemV3.Web\Areas";
            DirectoryInfo root = new DirectoryInfo(rootPath);
            DirectoryInfo[] dics = root.GetDirectories();
            for (int i = 0; i < dics.Length; i++)
            {
                string dicName = dics[i].Name;
                string nodePath = dics[i].FullName;
                string paths = nodePath + "\\Controllers\\";
                #region 开始读取文件
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(paths);
                    if (directoryInfo.Exists == false)
                    {
                        continue;
                    }
                    FileStream fs = null;
                    StreamWriter sw = null;
                    if (!System.IO.File.Exists($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt"))
                    {
                        fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                        System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                        sw = new StreamWriter(fs);
                    }
                    else
                    {
                        fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Write);
                        System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                        sw = new StreamWriter(fs);
                    }

                    FileInfo[] files = directoryInfo.GetFiles();

                    for (int j = 0; j < files.Length; j++)
                    {

                        if (files[j].Extension.Equals(".cs"))
                        {
                            Console.WriteLine("--------------------------------------------------------------------");
                            Console.WriteLine($"文件名：{files[j].Name}");
                            sw.WriteLine("--------------------------------------------------------------------");
                            sw.WriteLine($"文件名：{files[j].Name}");
                            string SOPName = "";
                            string filePath = paths + "" + files[j].Name;
                            try
                            {
                                using (StreamReader sr = new StreamReader(filePath))
                                {
                                    string line;
                                    // 从文件读取并显示行，直到文件的末尾 
                                    int index = 1;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line.Contains("[FunctionDescription"))
                                        {
                                            string lineTxt = $"{index++}-{line}";
                                            Console.WriteLine(lineTxt);
                                            sw.WriteLine(lineTxt);//写入值
                                            break;
                                        }
                                    }
                                    List<string> filesNameList = new List<string>();
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        if (line.Contains("model.ServiceName"))
                                        {
                                            SOPName = line.Substring(line.IndexOf("NodeNameConstant.")).Replace(";", "");
                                            filesNameList.Add(SOPName);
                                        }
                                        if (line.Contains("JobQueueUtil.AddQueueTask"))
                                        {
                                            if (line.IndexOf("EventBusTaskType.") > 0)
                                            {
                                                SOPName = line.Substring(line.IndexOf("EventBusTaskType."));
                                                int indexEnd = SOPName.IndexOf(",");
                                                var SOPNameStr = SOPName.Substring(0, indexEnd);
                                                filesNameList.Add(SOPNameStr);
                                            }
                                        }
                                    }
                                    if (filesNameList.Count > 0)
                                    {
                                        var DisfilesNameList = filesNameList.Distinct().ToList();
                                        foreach (var item in DisfilesNameList)
                                        {
                                            Console.WriteLine(item);
                                            sw.WriteLine(item);//写入值
                                        }
                                    }


                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                        }
                    }

                    sw.Close();
                    fs.Close();
                }
                #endregion
            }
            Console.ReadLine();
        }

        public static void GetGetControllerServicesListVI()
        {
            Console.WriteLine("开始遍历目录...");
            DataSet dm = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Pages";
            dm.Tables.Add(dt);
            dm.Tables[0].Columns.Add("Controller");
            dm.Tables[0].Columns.Add("FunctionDescription");
            dm.Tables[0].Columns.Add("Services");

            string rootPath = @"D:\WorkBao\XiangMuBao\OscarSystemV3.Web\Areas";
            DirectoryInfo root = new DirectoryInfo(rootPath);
            DirectoryInfo[] dics = root.GetDirectories();
            FileStream fs = null;
            StreamWriter sw = null;
            string dicName = "服务方法";
            if (!System.IO.File.Exists($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt"))
            {
                fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                sw = new StreamWriter(fs);
            }
            else
            {
                fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Write);
                System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                sw = new StreamWriter(fs);
            }
            for (int i = 0; i < dics.Length; i++)
            {
                //string dicName = dics[i].Name;
                string nodePath = dics[i].FullName;
                string paths = nodePath + "\\Controllers\\";
                #region 开始读取文件
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(paths);
                    if (directoryInfo.Exists == false)
                    {
                        continue;
                    }
                    FileInfo[] files = directoryInfo.GetFiles();

                    for (int j = 0; j < files.Length; j++)
                    {
                        if (files[j].Extension.Equals(".cs"))
                        {
                            Console.WriteLine("--------------------------------------------------------------------");
                            Console.WriteLine($"文件名：{files[j].Name}");
                            //sw.WriteLine("--------------------------------------------------------------------");
                            //sw.WriteLine($"文件名：{files[j].Name}");
                            string SOPName = "";
                            string filePath = paths + "" + files[j].Name;
                            try
                            {
                                string functionDescription = "";
                                using (StreamReader sr = new StreamReader(filePath))
                                {
                                    string line;
                                    // 从文件读取并显示行，直到文件的末尾 
                                    int index = 1;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line.Contains("[FunctionDescription"))
                                        {
                                            string lineTxt = $"{index++}-{line}";
                                            Console.WriteLine(lineTxt);
                                            functionDescription = line;
                                            //sw.WriteLine(lineTxt);//写入值
                                            break;
                                        }
                                    }
                                    List<string> filesNameList = new List<string>();
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        if (line.Contains("model.ServiceName"))
                                        {
                                            SOPName = line.Substring(line.IndexOf("NodeNameConstant.")).Replace(";", "");
                                            filesNameList.Add(SOPName);
                                        }
                                        if (line.Contains("JobQueueUtil.AddQueueTask"))
                                        {
                                            if (line.IndexOf("EventBusTaskType.") > 0)
                                            {
                                                SOPName = line.Substring(line.IndexOf("EventBusTaskType."));
                                                int indexEnd = SOPName.IndexOf(",");
                                                var SOPNameStr = SOPName.Substring(0, indexEnd);
                                                filesNameList.Add(SOPNameStr);
                                            }
                                        }
                                    }
                                    if (filesNameList.Count > 0)
                                    {
                                        //sw.WriteLine("--------------------------------------------------------------------");
                                        //sw.WriteLine($"文件名：{files[j].Name}");
                                        //sw.WriteLine($"描述：{functionDescription}");

                                        var DisfilesNameList = filesNameList.Distinct().ToList();
                                        string strService = "";
                                        foreach (var item in DisfilesNameList)
                                        {
                                            strService += item + ";";
                                            //Console.WriteLine(strService);
                                            //sw.WriteLine(item);//写入值
                                            DataRow dr = dt.NewRow();
                                            dr["Controller"] = files[j].Name.Trim();
                                            dr["FunctionDescription"] = functionDescription.Trim();
                                            dr["Services"] = item.Trim();
                                            dm.Tables[0].Rows.Add(dr);
                                        }
                                        Console.WriteLine(strService);
                                        sw.WriteLine(files[j].Name.Trim() + " " + functionDescription.Trim() + " " + strService.Trim().TrimEnd(';'));//写入值

                                        //{
                                        //    DataRow dr = dt.NewRow();
                                        //    dr["Controller"] = files[j].Name.Trim();
                                        //    dr["FunctionDescription"] = functionDescription.Trim();
                                        //    dr["Services"] = strService.Trim().TrimEnd(';');
                                        //    dm.Tables[0].Rows.Add(dr);
                                        //}
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                        }
                    }

                }
                #endregion
            }
            sw.Close();
            fs.Close();
            {
                Export(dm);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// excel导出功能
        /// </summary>
        /// <returns></returns>
        public static void Export(DataSet dbSet)
        {
            string sWebRootFolder = @"D:\Getdll\ControllersFiles";
            string sFileName = $"服务对应查询{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));  //Path.Combine把多个字符串组成一个路径
            using (ExcelPackage package = new ExcelPackage(file))   //ExcelPackage 操作excel的主要对象
            {
                // 添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                //添加头
                worksheet.Cells[1, 1].Value = "Controller";
                worksheet.Cells[1, 2].Value = "FunctionDescription";
                worksheet.Cells[1, 3].Value = "Services";
                //添加值
                if (dbSet.Tables != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow item in dbSet.Tables[0].Rows)
                    {
                        i++;
                        string strA = "A" + i;
                        string strB = "B" + i;
                        string strC = "C" + i;
                        worksheet.Cells[strA].Value = item[0].ToString();
                        worksheet.Cells[strB].Value = item[1].ToString();
                        worksheet.Cells[strC].Value = item[2].ToString();

                    }
                }
                package.Save();
            }
        }

        public static void GetGetTables()
        {
            Console.WriteLine("开始遍历目录...");

            string rootPath = @"C:\Users\CBF\Desktop\导出数据";
            DirectoryInfo root = new DirectoryInfo(rootPath);
            DirectoryInfo[] dics = root.GetDirectories();
            for (int i = 0; i < dics.Length; i++)
            {
                string dicName = dics[i].Name;
                string nodePath = dics[i].FullName;
                string paths = nodePath;// + "\\txt\\";
                #region 开始读取文件
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(paths);
                    if (directoryInfo.Exists == false)
                    {
                        continue;
                    }
                    FileStream fs = null;
                    StreamWriter sw = null;
                    if (!System.IO.File.Exists($@"C:\Users\CBF\Desktop\导出数据\结果\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt"))
                    {
                        fs = new FileStream($@"C:\Users\CBF\Desktop\导出数据\结果\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                        System.IO.File.SetAttributes($@"C:\Users\CBF\Desktop\导出数据\结果\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                        sw = new StreamWriter(fs);
                    }
                    else
                    {
                        fs = new FileStream($@"C:\Users\CBF\Desktop\导出数据\结果\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Write);
                        System.IO.File.SetAttributes($@"C:\Users\CBF\Desktop\导出数据\结果\{dicName}_Txt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                        sw = new StreamWriter(fs);
                    }

                    FileInfo[] files = directoryInfo.GetFiles();

                    for (int j = 0; j < files.Length; j++)
                    {

                        if (files[j].Extension.Equals(".txt"))
                        {
                            Console.WriteLine("--------------------------------------------------------------------");
                            Console.WriteLine($"文件名：{files[j].Name}");
                            sw.WriteLine("--------------------------------------------------------------------");
                            sw.WriteLine($"文件名：{files[j].Name}");
                            string SOPName = "";
                            string filePath = paths + "\\" + files[j].Name;
                            try
                            {
                                using (StreamReader sr = new StreamReader(filePath))
                                {
                                    string line;
                                    // 从文件读取并显示行，直到文件的末尾 
                                    int index = 1;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line.Contains("T_"))
                                        {
                                            string lineTxt = $"{index++}-{line}";
                                            Console.WriteLine(lineTxt);
                                            sw.WriteLine(lineTxt);//写入值
                                            break;
                                        }
                                    }
                                    List<string> filesNameList = new List<string>();
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        if (line.Contains("model.ServiceName"))
                                        {
                                            SOPName = line.Substring(line.IndexOf("NodeNameConstant.")).Replace(";", "");
                                            filesNameList.Add(SOPName);
                                        }
                                        if (line.Contains("JobQueueUtil.AddQueueTask"))
                                        {
                                            if (line.IndexOf("EventBusTaskType.") > 0)
                                            {
                                                SOPName = line.Substring(line.IndexOf("EventBusTaskType."));
                                                int indexEnd = SOPName.IndexOf(",");
                                                var SOPNameStr = SOPName.Substring(0, indexEnd);
                                                filesNameList.Add(SOPNameStr);
                                            }
                                        }
                                    }
                                    if (filesNameList.Count > 0)
                                    {
                                        var DisfilesNameList = filesNameList.Distinct().ToList();
                                        foreach (var item in DisfilesNameList)
                                        {
                                            Console.WriteLine(item);
                                            sw.WriteLine(item);//写入值
                                        }
                                    }


                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                        }
                    }

                    sw.Close();
                    fs.Close();
                }
                #endregion
            }
            Console.ReadLine();
        }



    }



}
