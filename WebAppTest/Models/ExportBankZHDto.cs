using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class ExportBankZHDto 
    {
        /// <summary>
        /// 工单编号
        /// </summary>
        public string WorkOrderNo { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 回电客户（关系）Id
        /// </summary>
        public long TelRelationId { get; set; }
        /// <summary>
        /// 回电客户（关系）
        /// </summary>
        public string TelRelation { get; set; }
        /// <summary>
        /// 固定号码
        /// </summary>
        public string FixedNumber { get; set; }
        /// <summary>
        /// 回电结果Id
        /// </summary>
        public long CallBackResults { get; set; }
        /// <summary>
        /// 回电结果
        /// </summary>
        public string CallBackResultsName { get; set; }
        /// <summary>
        /// 回电时间
        /// </summary>
        public DateTime? CallBackTime { get; set; }
        /// <summary>
        /// 具体内容
        /// </summary>
        public string ConcreteContent { get; set; }
        /// <summary>
        /// 备注（客服添加此列）
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool IsCheck { get; set; }
    }
}