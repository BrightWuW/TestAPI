using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TestAPI
{
    class GetUrlIP
    {
        public static string GetUrlIPs(string strUrl)
        {
            Uri uri = new Uri(strUrl, false);
            string _strUrl = "";
            if (uri.Port == 80)
            {
                _strUrl = uri.Host;
            }
            else
            {
                _strUrl = uri.Host + ":" + uri.Port;
            }
            string urlIP = "";
            switch (_strUrl)
            {
                case "10.10.235.190:10081":
                    urlIP = "http://172.17.169.151:11190" + uri.AbsolutePath;
                    break;
                case "10.10.235.194:10081":
                    urlIP = "http://172.17.169.151:11194" + uri.AbsolutePath;
                    break;
                case "10.10.235.195:10081":
                    urlIP = "http://172.17.169.151:11195" + uri.AbsolutePath;
                    break;
                case "10.10.235.196:10081":
                    urlIP = "http://172.17.169.151:11196" + uri.AbsolutePath;
                    break;
                case "10.10.235.197:10081":
                    urlIP = "http://172.17.169.151:11197" + uri.AbsolutePath;
                    break;
                case "10.1.30.201:10081":
                    urlIP = "http://172.17.169.151:11201" + uri.AbsolutePath;
                    break;
                case "10.200.16.200":
                    urlIP = "http://172.17.169.151:22200" + uri.AbsolutePath;
                    break;
                case "172.20.21.131":
                    urlIP = "http://172.17.169.151:22131" + uri.AbsolutePath;
                    break;
                default:
                    urlIP = strUrl;
                    //SendEmailUtil.NetSendEmail($"原地址：{urlIP} 没有匹配到录音地址", "上传录音地址匹配", "leiql@icbf.com.cn", null);
                    break;
            }
            return urlIP;
        }

        public static string zhengZe()
        {
            MatchCollection ma = Regex.Matches("029-85816888", @"^[1][356789][0-9]{9}$");
            string workPhone = ma.Count > 0 ? ma[ma.Count - 1].Value : string.Empty;
            if (string.IsNullOrEmpty(workPhone))
            {
                Console.WriteLine("电话号码匹配失败");

            }
            return null;
        }

        public static string GetDatetime()
        {
            DateTime datetime = DateTime.Now;
            var dt = datetime.AddMonths(-1).Date.AddDays(1 - datetime.Day);//2020/6/1 0:00:00 上月{31号有问题少用}
            var dts = datetime.AddMonths(0).Date.AddDays(1 - datetime.Day).Date.AddSeconds(1); //2020/7/1 0:00:01 当前月1号0:00:01
            var agodt = datetime.AddMonths(-1);//上月
            DateTime dtage = new DateTime(datetime.Year, datetime.AddMonths(-1).Month, 1); //上月1号0时0分0秒   
            
            int numc = (int)Math.Ceiling(1.01);
            int count = Convert.ToInt32(Math.Ceiling(10001 / Convert.ToDouble(100)));
            int maxCount = 100;
            var dec = (decimal)(1000) / maxCount;
            int numb = (int)Math.Ceiling(dec);
            int numCount = (int)Math.Ceiling((decimal)(1001) / maxCount);
            var decNum= Math.Round((decimal)(1001)/ maxCount, 2);//两位小数
            return null;
        }
    }
}
