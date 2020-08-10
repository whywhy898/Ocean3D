using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.EventSourcing
{
    public class HostilityHistoryData : IEventData
    {
        public string QQNumber { get; set; }
        public string HostilityName { get; set; }
        [JsonProperty(PropertyName = "MessageType")]
        public string Action { get; set; }
        [JsonProperty(PropertyName = "UserName")]
        public string Who { get ; set ; }
        public DateTime Timestamp { get; set; }
    }
}
