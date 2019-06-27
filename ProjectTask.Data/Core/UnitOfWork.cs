using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Data.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectTaskDBContext Context { get; }

        public UnitOfWork(ProjectTaskDBContext context)
        {
            Context = context;
        }

        public TModel Get<TModel>(int id) where TModel : class
        {
            return Context.Find<TModel>(id);
        }

        public IQuery<TModel> Select<TModel>() where TModel : class
        {
            return new Query<TModel>(Context.Set<TModel>());
        }

        public void InsertRange<TModel>(IEnumerable<TModel> models) where TModel : class
        {
            Context.AddRange(models);
        }

        public void Insert<TModel>(TModel model) where TModel : class
        {
            Context.Add(model);
        }

        public void Update<TModel>(TModel model) where TModel : class
        {
            EntityEntry<TModel> entry = Context.Entry(model);
            if (entry.State != EntityState.Modified && entry.State != EntityState.Unchanged)
                entry.State = EntityState.Modified;

            entry.Property("CreateDate").IsModified = false;
        }

        public void DeleteRange<TModel>(IEnumerable<TModel> models) where TModel : class
        {
            Context.RemoveRange(models);
        }

        public void Delete<TModel>(TModel model) where TModel : class
        {
            Context.Remove(model);
        }

        public void Delete<TModel>(int id) where TModel : class
        {
            Delete(Context.Find<TModel>(id));
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task MigrateDatabaseAsync()
        {
            await Context.Database.MigrateAsync()
                .ConfigureAwait(false);
        }
    }
}
