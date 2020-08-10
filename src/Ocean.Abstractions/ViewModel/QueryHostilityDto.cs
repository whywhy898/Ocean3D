using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
   public class QueryHostilityDto: QueryDto
    {
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNumber { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string HostilityName { get; set; }
        /// <summary>
        /// 仇恨级别
        /// </summary>
        public string HostilityLevel { get; set; }
    }
}
