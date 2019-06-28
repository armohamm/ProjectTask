using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectTask.Data.Core;
using System.Linq;
using ProjectTask.ViewModels.Abstract;

namespace ProjectTask.Services.Abstract
{
    public abstract class CRUDServiceBase<TModel, TViewModel> : ServiceBase<TModel>, IService<TViewModel> 
        where TModel : Entity
        where TViewModel : class
    {
        public CRUDServiceBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public abstract IEnumerable<TViewModel> GetDTOs();

        public abstract TViewModel GetDTO(int id);

        public abstract Task SaveAsync(TViewModel viewModel);

        public virtual async Task DeleteAsync(int id)
        {
            await DoInTransactionScope(DeleteAsyncCore, id);
        }

        private async Task DeleteAsyncCore(int id)
        {
            var obj = GetActualRecords().Where(x => x.Id == id).Single();
            MarkAsDeleted(obj);
            await UnitOfWork.CommitAsync();
        }
    }
}
