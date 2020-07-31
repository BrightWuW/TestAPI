using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {
        #region API

        static void Main(string[] args)
        {

            //QuartzJobDemo.Start();//定时调度
            //GetDllMethord.GetMethords();//反射读取Methords

            //APIDemos.GetApiStopwatch();
            //APIDemos.GetApiStringJoin();
            //APIDemos.GetIp();//获取当前IP
            //GetFileds.GetFiledInfoList();//遍历指定目录下所有文件目录和其文件

            //GetControllerServices.GetGetControllerServicesList();//Controller文件分组生成文件
            //GetControllerServices.GetGetControllerServicesListVI();//单个文件
            //GetControllerServices.GetGetTables();//获取文件表
            //string url = "http://10.200.16.200";
            //string url = "http://10.10.235.190:10081";            
            //GetUrlIP.GetUrlIPs(url);
            //GetUrlIP.zhengZe();
            GetUrlIP.GetDatetime();
            
            Console.ReadLine();
        }
        #endregion

    }
}
