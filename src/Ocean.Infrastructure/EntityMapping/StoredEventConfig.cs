using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
  public  class StoredEventConfig : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("StoredEvent");
            builder.HasKey(a=>a.Id);

            builder.Property(a => a.Id).HasColumnType("varchar(50)");
            builder.Property(a => a.AggregateId).HasColumnType("uniqueidentifier");
            builder.Property(a => a.UserName).HasColumnType("varchar(100)");
            builder.Property(a => a.Data).HasColumnType("varchar(Max)");

            builder.Property(c => c.Timestamp)
                .HasColumnName("Timestamp")
                .HasColumnType("DateTime");

            builder.Property(c => c.MessageType)
                .HasColumnName("MessageType")
                .HasColumnType("varchar(100)");
        }
    }
}
