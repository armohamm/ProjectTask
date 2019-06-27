using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TModel Get<TModel>(int id) where TModel : class;

        IQuery<TModel> Select<TModel>() where TModel : class;

        void InsertRange<TModel>(IEnumerable<TModel> models) where TModel : class;
        void Insert<TModel>(TModel model) where TModel : class;

        void Update<TModel>(TModel model) where TModel : class;

        void Delete<TModel>(TModel model) where TModel : class;
        void Delete<TModel>(int id) where TModel : class;

        Task CommitAsync();

        Task MigrateDatabaseAsync();
    }
}
