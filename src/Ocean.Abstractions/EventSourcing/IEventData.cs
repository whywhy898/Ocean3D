using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.EventSourcing
{
   public interface IEventData
    {
        string Action { get; set; }

        string Who { get; set; }

        DateTime Timestamp { get; set; }
    }
}
