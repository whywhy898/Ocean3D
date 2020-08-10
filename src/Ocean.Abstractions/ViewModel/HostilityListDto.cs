using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
  public  class HostilityListDto
    {
        public string HostilityId { get;  set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNumber { get;  set; }
        /// <summary>
        /// 仇恨姓名
        /// </summary>
        public string HostilityName { get;  set; }
        /// <summary>
        /// 仇恨级别
        /// </summary>
        public string RoleLevel { get;  set; }
        /// <summary>
        /// 总战力
        /// </summary>
        public int? MilitaryPower { get;  set; }
        /// <summary>
        /// 仇恨状态
        /// </summary>
        public string HostilityLevel { get;  set; }
        /// <summary>
        /// 是否超越
        /// </summary>
        public bool IsSurpass { get; protected set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }


    }
}
