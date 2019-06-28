using ProjectTask.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectTask.Data.Configuration
{
    internal class PacientsConfiguration : DbEntityConfiguration<Pacient>
    {
        public override void Configure(EntityTypeBuilder<Pacient> entity)
        {
            entity.ToTable("pacients");

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

            #region default configuration for human
            entity.Property(x => x.IIN)
                .HasColumnName("IIN")
                .HasMaxLength(12)
                .IsFixedLength()
                .IsRequired();

            entity.Property(x => x.Address)
                .HasColumnName("address")
                ;
            entity.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired();

            entity.Property(x => x.LastName).HasColumnName("last_name");
            entity.Property(x => x.SurName).HasColumnName("surname");
            entity.Property(x => x.PhoneNumber).HasColumnName("phone_number");
            #endregion

        }
    }
}
