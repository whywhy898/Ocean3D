using Microsoft.EntityFrameworkCore;
using Ocean.Domain.Core.Events;
using Ocean.Infrastructure.EntityMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.Context
{
   public class StoreDbContext:DbContext
    {
        public DbSet<StoredEvent> storedEvents { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> option) : base(option)
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
