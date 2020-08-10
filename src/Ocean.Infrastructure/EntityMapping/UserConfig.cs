using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Model.User.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
   public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SystemUser");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                   .HasColumnName("Id")
                   .HasColumnType("varchar(50)");

            builder.Property(a => a.Name)
                  .HasColumnName("Name")
                  .HasColumnType("varchar(50)");

            builder.Property(a => a.Nick)
                   .HasColumnName("Nick")
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(a => a.AccountName)
                   .HasColumnName("AccountName")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(a => a.PassWord)
                   .HasColumnName("PassWord")
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(a => a.QQNumber)
                   .HasColumnName("QQNumber")
                   .HasColumnType("varchar(20)");

            builder.Property(a => a.Tel)
                   .HasColumnName("Tel")
                   .HasColumnType("varchar(20)");

            builder.Property(a => a.EmadilAddress)
                   .HasColumnName("EmadilAddress")
                   .HasColumnType("varchar(100)");

            builder.Property(a => a.Enabled)
                    .HasColumnName("Enabled")
                    .HasColumnType("bit");

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
                .WithOne()
                .HasForeignKey(a => a.UserId)
                .IsRequired(false);

            builder.OwnsOne(o => o.address,sa=> { 
                sa.Property(p => p.Province)
                  .HasColumnName("AddressProvince")
                  .HasColumnType("varchar(50)");
                sa.Property(p => p.City)
                  .HasColumnName("AddressCity")
                  .HasColumnType("varchar(50)");
                sa.Property(p => p.Location)
                  .HasColumnName("AddressLocation")
                  .HasColumnType("varchar(50)");
            });

            builder.HasMany(a => a.userRoleRelations)
                   .WithOne(a=>a.UserInfo)
                   .HasForeignKey(a => a.UserId);

            builder.HasQueryFilter(a => a.Enabled == false);
        }

    }
}
