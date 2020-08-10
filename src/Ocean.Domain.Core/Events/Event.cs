using MediatR;
using System;

namespace Ocean.Domain.Core.Events
{
    public abstract class Event :INotification
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; private set; }
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
    }
}
