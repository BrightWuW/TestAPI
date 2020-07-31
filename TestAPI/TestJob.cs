using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class TestJob : IJob
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(TestJob));
        /// <summary>
        /// 测试作业
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            // 在这里处理你的任务
            await Task.Run(() =>
            {
                _log.Debug("run TestJob debug");
                _log.Error("run TestJob error");
                _log.Info("run TestJob info");
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string k = dataMap.GetString("key");//获取参数(可根据传递的类型使用GetInt、GetFloat、GetString.....)                
                Console.WriteLine($"My Job Time：{DateTime.Now}");
            });
        }
    }
}
