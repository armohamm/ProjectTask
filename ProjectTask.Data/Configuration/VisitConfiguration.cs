using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Configuration
{
    internal class VisitConfiguration : DbEntityConfiguration<Visit>
    {
        public override void Configure(EntityTypeBuilder<Visit> entity)
        {
            entity.ToTable("visits");

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

            entity.Property(x => x.Complaints)
               .HasColumnName("complaints")
               .IsRequired();

            entity.Property(x => x.Diagnosis)
                .HasColumnName("diagnosis")
                .IsRequired();

            entity.Property(x => x.VisitDate)
                .HasColumnName("visit_date")
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(x => x.DoctorId)
                .HasColumnName("doctor_id")
                .IsRequired();

            entity.Property(x => x.DoctorTypeId)
                .HasColumnName("doctor_type_id")
                .IsRequired();

            entity.Property(x => x.PacientId)
                .HasColumnName("pacient_id")
                .IsRequired();

            #region db relationships
            entity.HasOne(x => x.Doctor)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.DoctorType)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.DoctorTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Pacient)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.PacientId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
