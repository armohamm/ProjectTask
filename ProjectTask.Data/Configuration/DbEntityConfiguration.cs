using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTask.Data.Core;

namespace ProjectTask.Data.Configuration
{
    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
