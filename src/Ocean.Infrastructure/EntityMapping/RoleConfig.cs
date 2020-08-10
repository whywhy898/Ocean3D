using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Model.Role.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("SystemRole");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("varchar(50)");
            builder.Property(a => a.RoleName)
                .HasColumnName("RoleName")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.CreateTime)
                  .HasColumnName("CreateTime")
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("getdate()");

            builder.Property(a => a.CreateBy)
                .HasColumnName("CreateBy")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.UpdateBy)
                .HasColumnName("UpdateBy")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.UpdateTime)
                .HasColumnName("UpdateTime")
                .HasColumnType("datetime");

            builder.HasMany(a => a.userRoleRelations)
                .WithOne(a=>a.RoleInfo)
                .HasForeignKey(a=>a.RoleId);
        }
    }
}
