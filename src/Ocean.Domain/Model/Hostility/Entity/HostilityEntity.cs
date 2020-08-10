using Ocean.Domain.Core.SeedWork;
using Ocean.Domain.Hostility.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Hostility.Entity
{
   /// <summary>
   /// 仇恨信息
   /// </summary>
   public class HostilityEntity: BaseEntity<string> , IAggregateRoot
    {
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNumber { get; protected set; }
        /// <summary>
        /// 仇恨姓名
        /// </summary>
        public string HostilityName { get; protected set; }
        /// <summary>
        /// 仇恨级别
        /// </summary>
        public int RoleLevel { get; protected set; }
        /// <summary>
        /// 总战力
        /// </summary>
        public int? MilitaryPower { get; protected set; }
        /// <summary>
        /// 仇恨状态
        /// </summary>
        public string HostilityLevel { get; protected set; }
        /// <summary>
        /// 是否超越
        /// </summary>
        public bool IsSurpass { get; protected set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; protected set; }


        protected HostilityEntity() { }
      
        public HostilityEntity(string hostilityId, string qqNumber,string hostilityName,int roleLevel,
            int? militaryPower,string hostilityLevel,string remark,string createBy,bool isSurpass= false) 
        {
            Id = hostilityId;
            QQNumber = qqNumber;
            HostilityName = hostilityName;
            RoleLevel = roleLevel;
            MilitaryPower = militaryPower;
            HostilityLevel = hostilityLevel;
            IsSurpass = isSurpass;
            Remark = remark;
            CreateTime = DateTime.Now;
            CreateBy = createBy;
            UpdateTime = DateTime.Now;
            UpdateBy = createBy;

            AddInfo(hostilityId, qqNumber, hostilityName, roleLevel, militaryPower, hostilityLevel, remark, createBy);
        }

        public void SetSurpass()
        {
            IsSurpass = true;
        }

        public void AddInfo(string hostilityId, string qqNumber, string hostilityName, int roleLevel,
            int? militaryPower, string hostilityLevel, string remark, string createBy, bool isSurpass = false)
        {
            var hotilityevent = new CraetedHotilityEvent(hostilityId, qqNumber, hostilityName, roleLevel, militaryPower, hostilityLevel, isSurpass, remark);
            this.AddDomainEvent(hotilityevent);
        }
    }
}
