using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocean.Domain.Model.Relation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.EntityMapping
{
    public class UserRoleRelationConfig : IEntityTypeConfiguration<UserRoleRelation>
    {
        public void Configure(EntityTypeBuilder<UserRoleRelation> builder)
        {
            builder.ToTable("SystemUserRoleRelation");
            builder.HasKey(a=>a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("Id")
                   .HasColumnType("varchar(50)");

            builder.Property(a => a.UserId)
                   .HasColumnName("UserId")
                   .HasColumnType("varchar(50)");

            builder.Property(a => a.RoleId)
                    .HasColumnName("RoleId")
                    .HasColumnType("varchar(50)");


        }
    }
}
