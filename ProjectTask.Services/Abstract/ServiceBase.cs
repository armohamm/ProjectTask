using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectTask.Services.Abstract
{
    public abstract class ServiceBase<T> : IDisposable where T : Entity
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        ~ServiceBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
        }

        protected IQueryable<T> GetActualRecords() => GetCollection().Where(x => !x.IsDeleted);
        protected IQueryable<T> GetCollection() => UnitOfWork.Select<T>();

        protected void MarkAsDeleted(object result)
        {
            var res = result as IEntity<int>;

            if (res != null)
            {
                res.IsDeleted = true;
                res.LastEditedAt = DateTime.Now;
            }
            else
            {
                var type = result?.GetType() ?? typeof(object);
                throw new InvalidCastException(string.Format("{0} can not be cast to {1}", type, typeof(Entity)));
            }
        }
        /// <summary>
        ///  Получает или создает класс в коллекции
        /// </summary>
        /// <typeparam name="TResult"> Возвращаемая модель </typeparam>
        /// <param name="sourceCollection"> Коллекция </param>
        /// <param name="whereConditions"> Условие для поиска в коллекции </param>
        /// <returns> Возвращает кортеж (модель создан, модель) </returns>
        protected Tuple<bool, TResult> GetOrCreateEntity<TResult>(
            IQueryable<TResult> sourceCollection,
            Expression<Func<TResult, bool>> whereConditions)
            where TResult : class, new()
        {
            var isCreated = false;
            var result = sourceCollection.Where(whereConditions).FirstOrDefault();

            if (result == null)
            {
                isCreated = true;
                result = new TResult();
                UnitOfWork.Insert(result);
            }

            return new Tuple<bool, TResult>(isCreated, result);
        }

        /// <summary>
        /// Выполнить внутри транзакции
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="action"> Вызываемый метод </param>
        /// <param name="model"> Посылаемая модель в парамеры метода </param>
        protected async Task DoInTransactionScope<TModel>(Func<TModel, Task> action, TModel model)
        {
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await action(model);

                ts.Complete();
            }
        }
    }
}
