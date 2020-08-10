using Newtonsoft.Json;
using Ocean.Domain.Core.Events;
using Ocean.Infrastructure.Repositorys.store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EventBus
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        public EventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "admin");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
