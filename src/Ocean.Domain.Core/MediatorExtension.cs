using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ocean.Domain.Core.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ocean.Domain.Core.Bus;

namespace Ocean.Domain.Core
{
   public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync<keyT>(this IMediatorHandler mediator, BaseContext ctx) where keyT:class
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity<keyT>>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.PublishEvent(domainEvent);
        }
    }
}
