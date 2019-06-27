using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Configuration
{
    internal class RelDoctorDoctorTypeConfiguration : DbEntityConfiguration<RelDoctorDoctorType>
    {
        public override void Configure(EntityTypeBuilder<RelDoctorDoctorType> entity)
        {
            entity.HasKey(e => new { e.DoctorId, e.DoctorTypeId});

            entity.ToTable("rel_doctor_doctor_type");

            entity.Property(x => x.DoctorId)
                .HasColumnName("doctor_id");

            entity.Property(x => x.DoctorTypeId)
                .HasColumnName("doctor_type_id");

            #region db relationships
            entity.HasOne(x => x.Doctor)
                .WithMany(x => x.RelDoctorDoctorTypes)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.DoctorType)
                .WithMany(x => x.RelDoctorDoctorTypes)
                .HasForeignKey(x => x.DoctorTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
