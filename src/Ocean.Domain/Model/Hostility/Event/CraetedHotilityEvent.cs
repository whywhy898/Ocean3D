using MediatR;
using Ocean.Domain.Hostility.Entity;
using Ocean.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Hostility.Event
{
   public class CraetedHotilityEvent: Core.Events.Event
    {
        public string Id { get; set; }
        public string QQNumber { get; set; }
        public string HostilityName { get; protected set; }
        public int RoleLevel { get; protected set; }
        public int? MilitaryPower { get; protected set; }
        public string HostilityLevel { get; protected set; }
        public bool IsSurpass { get; protected set; }
        public string Remark { get; protected set; }

        public CraetedHotilityEvent(string id,string qqNumber,string hostilityName,int roleLevel,
            int? militaryPower,string hostilityLevel,bool isSurpass, string remark)
        {
            Id= id;
            QQNumber = qqNumber;
            HostilityName=hostilityName;
            RoleLevel = roleLevel;
            MilitaryPower = militaryPower;
            HostilityLevel = hostilityLevel;
            IsSurpass = isSurpass;
            Remark = remark;
            AggregateId = Guid.Parse(id);
        }
    }
}
