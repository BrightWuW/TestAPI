using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace TestAPI
{
    class APIDemos
    {
        /// <summary>
        /// 监听耗时，性能对比
        /// </summary>
        public static void GetApiStopwatch()
        {
            #region 监听耗时，性能对比
            Stopwatch sw = new Stopwatch();
            long num = 0;
            sw.Reset();
            sw = Stopwatch.StartNew();
            for (int i = 1; i < 10000000; i++) num += 1;
            sw.Stop();
            TimeSpan el = sw.Elapsed;
            Console.WriteLine("花费 {0} ", el);
            long ms = sw.ElapsedMilliseconds;
            Console.WriteLine("花费 {0} 毫秒", ms);

            long num2 = 0;
            sw.Reset();
            sw = Stopwatch.StartNew();
            for (int i = 1; i < 10000000; i++) num2 += 1;
            sw.Stop();
            TimeSpan el2 = sw.Elapsed;

            sw.Reset();
            sw = Stopwatch.StartNew();
            List<string> strList = new List<string>();
            List<string> strListRa = new List<string>();
            List<string> telWorkList = new List<string>() { "str1", "str2", "str3", "str4" };
            for (int i = 0; i < 10000; i++)
            {
                telWorkList.Add("str_" + i);
                break;
            }

            sw.Reset();
            sw = Stopwatch.StartNew();
            strListRa.AddRange(telWorkList);
            sw.Stop();
            TimeSpan el3 = sw.Elapsed;

            sw.Reset();
            sw = Stopwatch.StartNew();
            foreach (var item in telWorkList)
            {
                strList.Add(item);
            }
            sw.Stop();
            TimeSpan el4 = sw.Elapsed;
            #endregion
        }

        /// <summary>
        /// 截取拼接字符串
        /// </summary>
        public static void GetApiStringJoin()
        {
            for (int i = 0; i < 105; i++)
            {
                if ((i + 1) % 100 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            List<int> intList = new List<int>() { 1,2,3,4,5};
            int intss = 6;
            var bbs = intList.Where(x=>x==intss);
            bool bbss = intList.Where(x => x == intss).Count()>0;

            string strTimeNow = DateTime.Now.ToString("yyyy-MM-dd");
            string strTimeNow1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            string Location = "OscarSystemV3.Web.Controllers.AccountController-->LoginDo";
            int idxStart = Location.LastIndexOf(".")+1;
            int idxend = Location.IndexOf("-");
            string values = Location.Substring(idxStart, idxend - idxStart);//AccountController

            string value = Location.Substring(idxStart, Location.Length - idxStart);
            string LocationCN = Location.Substring(Location.IndexOf("Controllers."));



            String strjson = "20200617131544707_783_9004_.docx,20200617131544707_783_9004_.docx，20200617131544707_783_9004_.docx";
            JObject joo = JObject.Parse(strjson);//或者JObject jo = JObject.Parse(jsonText);
            JObject jo = (JObject)JsonConvert.DeserializeObject(strjson);//或者JObject jo = JObject.Parse(jsonText);


            string strRedis = "skfj2019;sfad2010";
            string[] arr = strRedis.Split(";");


            #region 截取拼接字符串
            string assessmentType = "一，二，三，四";
            var assessment = assessmentType.Split('，').ToList();

            var sql = new StringBuilder();
            sql.Append("(");
            sql.Append(string.Join(",", assessment.ToArray()));
            sql.Append(")");

            var sqles = new StringBuilder();
            sqles.Append("('");
            sqles.Append(string.Join("','", assessment.ToArray()));
            sqles.Append("')");

            var sqlstr = new StringBuilder();
            for (int i = 0; i < assessment.Count; i++)
            {
                sqlstr.Append("'" + assessment[i] + "'");
                if (i != sqlstr.Length - 1)
                {
                    sqlstr.Append(",");
                }
            }

            string str = "result = JobQueueUtil.AddQueueTask(this, taskName, EventBusMessageType.OscarSystemBusMessage, EventBusTaskType.ExportAccountSearch, param, myUserId, userName);";
            string strT = str.Substring(str.IndexOf("EventBusMessageType."));
            string strTS = str.Substring(str.IndexOf("EventBusTaskType."));
            int indexs = str.IndexOf("EventBusMessageType.");
            int indexst = str.IndexOf("EventBusTaskType.");

            #endregion

        }

        /// <summary>
        /// 获取本地的IP地址
        /// </summary>
        public static void GetIp()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            Console.WriteLine($"Host name: { Dns.GetHostName()}");//计算机名称
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                    Console.WriteLine($"IP Address : {AddressIP} ");
                }
            }

        }

    }
}
