using System;

namespace Ocean.Domain.Core.Events
{
    public  class StoredEvent: Event
    {
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid().ToString();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            UserName = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public string Id { get; private set; }

        public string Data { get; private set; }

        public string UserName { get; private set; }
    }
}
