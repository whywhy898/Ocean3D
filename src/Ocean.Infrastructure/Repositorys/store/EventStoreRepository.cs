using Microsoft.EntityFrameworkCore;
using Ocean.Domain.Core.Events;
using Ocean.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Infrastructure.Repositorys.store
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly StoreDbContext _context;

        public EventStoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            return await _context.storedEvents.Where(a=>a.AggregateId== aggregateId).ToListAsync();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.storedEvents.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
