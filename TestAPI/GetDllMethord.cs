using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace TestAPI
{
    class GetDllMethord
    {
        public static void GetMethords()
        {

            //dll文件路径
            //string path = @"D:\Getdll\dll\OscarSystemV3.Web.dll";
            string path = @"D:\Getdll\dll\GuidanceSystem.Common.dll";

            //加载dll文件
            Assembly asm = Assembly.LoadFile(path);
            string pattern = @"\w*\.";
            Match match = Regex.Match(path, pattern);
            //获取类
            Type[] T = asm.GetTypes();
            string sysName = "SystemServiceProxy";
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i].Name.Contains(sysName))
                {
                    Console.WriteLine(T[i].Name);//类名
                    string namespace_class = match.Value + "Common.Clients." + T[i].Name;
                    Type type = asm.GetType(namespace_class);
                    for (int index = 0; index < type.GetMethods().Length - 4; index++)
                    {
                        Console.WriteLine(type.GetMethods()[index].Name);
                        MethodInfo mf = type.GetMethod(type.GetMethods()[index].Name); //获取该类的方法
                    }

                }
            }
        }
    }
}
