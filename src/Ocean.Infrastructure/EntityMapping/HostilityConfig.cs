using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Hostility.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
    public class HostilityConfig : IEntityTypeConfiguration<HostilityEntity>
    {
        public void Configure(EntityTypeBuilder<HostilityEntity> builder)
        {
            builder.ToTable("Hostility");
            builder.HasKey(a=>a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("HostilityId")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.QQNumber)
                .HasColumnName("QQNumber")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(a => a.HostilityName)
                .HasColumnName("HostilityName")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(a => a.RoleLevel)
                .HasColumnName("RoleLevel")
                .HasColumnType("int")
                .IsRequired();


            builder.Property(a => a.MilitaryPower)
                .HasColumnName("MilitaryPower")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.IsSurpass)
                .HasColumnName("IsSurpass")
                .HasColumnType("bit");

            builder.Property(a => a.Remark)
                .HasColumnName("Remark")
                .HasColumnType("varchar(1000)");

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

        }
    }
}
