using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SOAQuery
{
    class GetTexts
    {
        private static GetTexts instance = new GetTexts();
        /// <summary>
        /// 读取单个文件
        /// </summary>
        public static void GetTextMethod()
        {
            Console.WriteLine("开始读取文件...");
            //文件路径
            string filePath = @"D:\Getdll\CS\GuidanceSystem.ServiceProxy.cs";
            //string filePath = @"D:\Getdll\CS\testText.txt";
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // 从文件读取并显示行，直到文件的末尾 
                    int i = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("model.ActionName") || line.Contains("model.ControllerName") || line.Contains("model.ServiceName"))
                        {
                            string lines = line.Replace("model.", "");
                            Console.WriteLine($"{i++}-{lines}");
                            if (i % 3 == 1)
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                    Console.WriteLine($"当前类共有{i / 3}个方法服务调用");
                }
            }
            catch (Exception)
            {
                throw;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 读取文件夹下的所有文件
        /// </summary>
        public static void GetTextMethods()
         {
            Console.WriteLine("开始读取文件...");
            FileStream fs = null;
            StreamWriter sw = null;
            if (!System.IO.File.Exists($@"D:\Getdll\CSService\SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt"))
            {
                fs = new FileStream($@"D:\Getdll\CSService\SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                System.IO.File.SetAttributes($@"D:\Getdll\CSService\SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                sw = new StreamWriter(fs);
            }
            else
            {
                fs = new FileStream($@"D:\Getdll\CSService\SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Write);
                System.IO.File.SetAttributes($@"D:\Getdll\CSService\SOATxt{DateTime.Now.ToString("yyyyMMdd")}.txt", FileAttributes.Hidden);
                sw = new StreamWriter(fs);
            }
            //文件路径
            string paths = @"D:\Getdll\CS\";
            DirectoryInfo directoryInfo = new DirectoryInfo(paths);
            FileInfo[] files = directoryInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension.Equals(".cs"))  
                {
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine($"文件名：{files[i].Name}");
                    sw.WriteLine("--------------------------------------------------------------------");
                    sw.WriteLine($"文件名：{files[i].Name}");
                    string SOPName = "";
                    string filePath = paths + "" + files[i].Name;
                    try
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            string line;
                            // 从文件读取并显示行，直到文件的末尾 
                            int index = 1;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains("model.ActionName") || line.Contains("model.ControllerName") || line.Contains("model.ServiceName"))
                                {
                                    string lines = line.Replace("model.", "");
                                    string lineTxt = $"{index++}-{lines}";
                                    Console.WriteLine(lineTxt);
                                    sw.WriteLine(lineTxt);//写入值
                                    if (index % 3 == 1)
                                    {
                                        Console.WriteLine();
                                        sw.WriteLine("");
                                    }
                                }
                                if (line.Contains("model.ServiceName"))
                                {
                                    SOPName = line.Substring(line.IndexOf("NodeNameConstant."));
                                }
                            }
                            Console.WriteLine($"当前类共有{index / 3}个方法服务调用{SOPName}");
                            sw.WriteLine($"当前类共有{index / 3}个方法服务调用{SOPName}");
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
            Console.ReadLine();
        }

    }
}
