using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestAPI
{
    class GetFileds
    {
        /// <summary>
        /// 读取指定文件夹下Controllers文件夹下所有Controller文件，并生成txt文件
        /// </summary>
        public static void GetFiledInfoList()
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
                    Console.WriteLine("开始读取文件...");
                    DirectoryInfo directoryInfo = new DirectoryInfo(paths);
                    if (directoryInfo.Exists == false)
                    {
                        continue;
                    }
                    FileStream fs = null;
                    StreamWriter sw = null;
                    if (!System.IO.File.Exists($@"D:\Getdll\ControllersFiles\{dicName}_SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt"))
                    {
                        fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                        System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                        sw = new StreamWriter(fs);
                    }
                    else
                    {
                        fs = new FileStream($@"D:\Getdll\ControllersFiles\{dicName}_SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Write);
                        System.IO.File.SetAttributes($@"D:\Getdll\ControllersFiles\{dicName}_SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
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
                                        if (line.Contains("[FunctionDescription") || line.Contains("model.ActionName") || line.Contains("model.ControllerName") || line.Contains("model.ServiceName"))
                                        {
                                            string lineTxt = $"{index++}-{line}";
                                            Console.WriteLine(lineTxt);
                                            sw.WriteLine(lineTxt);//写入值

                                        }
                                        if (line.Contains("model.ServiceName"))
                                        {
                                            SOPName = line.Substring(line.IndexOf("NodeNameConstant."));
                                            Console.WriteLine(SOPName);
                                            sw.WriteLine(SOPName);
                                        }
                                        if (line.Contains("JobQueueUtil.AddQueueTask"))
                                        {
                                            SOPName = line.Substring(line.IndexOf("EventBusMessageType."));
                                            Console.WriteLine(SOPName);
                                            sw.WriteLine(SOPName);
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
