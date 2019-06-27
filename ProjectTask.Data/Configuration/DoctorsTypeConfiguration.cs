using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Configuration
{
    internal class DoctorsTypeConfiguration : DbEntityConfiguration<DoctorType>
    {
        public override void Configure(EntityTypeBuilder<DoctorType> entity)
        {
            entity.ToTable("doctors_type");

            #region default configuration for entity
            entity.Property(e => e.Id)
              .HasColumnName("id")
              .ValueGeneratedOnAdd();

            entity.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            entity.Property(e => e.LastEditedAt)
                .HasColumnName("last_edit_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            #endregion


            entity.Property(x => x.Name).HasColumnName("type_name");

        }
    }
}
