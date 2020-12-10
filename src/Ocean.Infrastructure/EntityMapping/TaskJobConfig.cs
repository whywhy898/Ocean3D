using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Model.TaskSchedule.Entity;
using Ocean.Domain.Model.User.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
   public class TaskJobConfig : IEntityTypeConfiguration<TaskJob>
    {
        public void Configure(EntityTypeBuilder<TaskJob> builder)
        {
            builder.ToTable("TaskSchedule");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("TaskId");
            builder.Property(a => a.TaskGroup);
            builder.Property(a => a.TaskName);
            builder.Property(a => a.TaskCron);
            builder.Property(a => a.TaskCron);
        }

    }
}
