using ProjectTask.Data.Core;
using ProjectTask.Data.Models;
using ProjectTask.Services.Abstract;
using ProjectTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services
{
    public class DoctorTypeService : CRUDServiceBase<DoctorType, DoctorTypeViewModel>
    {
        public DoctorTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public override DoctorTypeViewModel GetDTO(int id)
        {
            var dbEntity = GetActualRecords().Where(x => x.Id == id).FirstOrDefault();

            return new DoctorTypeViewModel(dbEntity);
        }

        public override IEnumerable<DoctorTypeViewModel> GetDTOs()
        {
            return GetActualRecords().Select(x => new DoctorTypeViewModel(x));
        }

        public override async Task SaveAsync(DoctorTypeViewModel viewModel)
        {
            await DoInTransactionScope(SaveAsynCore, viewModel);
        }

        private async Task SaveAsynCore(DoctorTypeViewModel dto)
        {
            var entityTuple = GetOrCreateEntity(GetActualRecords(), x => x.Id == dto.Id);

            var entity = entityTuple.Item2;

            entity.Name = dto.Name;
            entity.LastEditedAt = DateTime.Now;

            if (entityTuple.Item1)
            {
                entity.CreateDate = DateTime.Now;
            }
            else
            {
                UnitOfWork.Update(entity);
            }

            await UnitOfWork.CommitAsync().ConfigureAwait(false);
        }

     
    }
}
