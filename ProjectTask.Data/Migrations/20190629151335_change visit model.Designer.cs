﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTask.Data;

namespace ProjectTask.Data.Migrations
{
    [DbContext(typeof(ProjectTaskDBContext))]
    [Migration("20190629151335_change visit model")]
    partial class changevisitmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTask.Data.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name");

                    b.Property<string>("IIN")
                        .IsRequired()
                        .HasColumnName("IIN");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastEditedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("last_edit_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<string>("SurName")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("ProjectTask.Data.Models.DoctorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastEditedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("last_edit_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasColumnName("type_name");

                    b.HasKey("Id");

                    b.ToTable("doctors_type");
                });

            modelBuilder.Entity("ProjectTask.Data.Models.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name");

                    b.Property<string>("IIN")
                        .IsRequired()
                        .HasColumnName("IIN");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastEditedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("last_edit_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<string>("SurName")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.ToTable("pacients");
                });

            modelBuilder.Entity("ProjectTask.Data.Models.RelDoctorDoctorType", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnName("doctor_id");

                    b.Property<int>("DoctorTypeId")
                        .HasColumnName("doctor_type_id");

                    b.HasKey("DoctorId", "DoctorTypeId");

                    b.HasIndex("DoctorTypeId");

                    b.ToTable("rel_doctor_doctor_type");
                });

            modelBuilder.Entity("ProjectTask.Data.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnName("complaints");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("create_date")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnName("diagnosis");

                    b.Property<int>("DoctorId")
                        .HasColumnName("doctor_id");

                    b.Property<int>("DoctorTypeId")
                        .HasColumnName("doctor_type_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastEditedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("last_edit_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("PacientId")
                        .HasColumnName("pacient_id");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnName("visit_date")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DoctorTypeId");

                    b.HasIndex("PacientId");

                    b.ToTable("visits");
                });

            modelBuilder.Entity("ProjectTask.Data.Models.RelDoctorDoctorType", b =>
                {
                    b.HasOne("ProjectTask.Data.Models.Doctor", "Doctor")
                        .WithMany("RelDoctorDoctorTypes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectTask.Data.Models.DoctorType", "DoctorType")
                        .WithMany("RelDoctorDoctorTypes")
                        .HasForeignKey("DoctorTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ProjectTask.Data.Models.Visit", b =>
                {
                    b.HasOne("ProjectTask.Data.Models.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectTask.Data.Models.DoctorType", "DoctorType")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectTask.Data.Models.Pacient", "Pacient")
                        .WithMany("Visits")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
