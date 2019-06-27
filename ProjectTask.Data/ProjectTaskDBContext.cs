using Microsoft.EntityFrameworkCore;
using ProjectTask.Data.Configuration;
using ProjectTask.Data.Models;

namespace ProjectTask.Data
{
    public sealed class ProjectTaskDBContext : DbContext
    {
        public ProjectTaskDBContext(DbContextOptions<ProjectTaskDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacient>(new PacientsConfiguration().Configure);
            modelBuilder.Entity<Doctor>(new DoctorsConfiguration().Configure);
            modelBuilder.Entity<DoctorType>(new DoctorsTypeConfiguration().Configure);
            modelBuilder.Entity<RelDoctorDoctorType>(new RelDoctorDoctorTypeConfiguration().Configure);
            modelBuilder.Entity<Visit>(new VisitConfiguration().Configure);
        }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorType> DoctorTypes { get; set; }
        public DbSet<RelDoctorDoctorType> RelDoctorDoctorTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
