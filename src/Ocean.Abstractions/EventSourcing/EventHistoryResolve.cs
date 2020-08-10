using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;
using Ocean.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Ocean.Application.EventSourcing
{
    public static class EventHistoryResolve
    {
        public static IList<T> ToJavaScriptHistory<T>(IList<StoredEvent> storedEvents) where T:IEventData
        {
            var HistoryData = new List<T>();

            storedEvents.ToList().ForEach(a => {
                var historyData = JsonConvert.DeserializeObject<T>(a.Data);
                historyData.Who = a.UserName;
                HistoryData.Add(historyData);
            });

            var sorted = HistoryData.OrderBy(c => c.Timestamp);

            return sorted.ToList();
        }

    }
}
