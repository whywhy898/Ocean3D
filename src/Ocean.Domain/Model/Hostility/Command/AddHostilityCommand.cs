using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Hostility.Command
{
   public class AddHostilityCommand:IRequest<bool>
    {
        public string QQNumber { get; set; }
        /// <summary>
        /// 仇恨姓名
        /// </summary>
        public string HostilityName { get; set; }
        /// <summary>
        /// 仇恨级别
        /// </summary>
        public int RoleLevel { get; set; }
        /// <summary>
        /// 总战力
        /// </summary>
        public int? MilitaryPower { get; set; }
        /// <summary>
        /// 仇恨状态
        /// </summary>
        public string HostilityLevel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public AddHostilityCommand(string qqNumber,string hostilityName,int roleLevel,int? militaryPower,string hostilityLevel,string remark)
        {
            QQNumber = qqNumber;
            HostilityName = hostilityName;
            RoleLevel = roleLevel;
            MilitaryPower = militaryPower;
            HostilityLevel = hostilityLevel;
            Remark = remark;
        }
    }
}
