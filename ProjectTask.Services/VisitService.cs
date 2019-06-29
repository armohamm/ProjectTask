using Microsoft.EntityFrameworkCore;
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
    public class VisitService : CRUDServiceBase<Visit, VisitViewModel>
    {
        public VisitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override VisitViewModel GetDTO(int id)
        {
            return GetActualRecords().Where(x => x.Id == id).Select(x => new VisitViewModel(x)).FirstOrDefault();
        }

        public override IEnumerable<VisitViewModel> GetDTOs()
        {
            return GetActualRecords().Select(x => new VisitViewModel(x));
        }

        public override async Task SaveAsync(VisitViewModel viewModel)
        {
            await DoInTransactionScope(Save, viewModel);
        }

        private async Task Save(VisitViewModel dto)
        {
            var entityTuple = GetOrCreateEntity(GetActualRecords(), x => x.Id == dto.Id);
            var entity = entityTuple.Item2;

            entity.LastEditedAt = DateTime.Now;
            entity.PacientId = dto.PacientId;
            entity.VisitDate = dto.VisitDate;
            entity.Complaints = dto.Complaints;
            entity.Diagnosis = dto.Diagnosis;
            entity.DoctorId = dto.DoctorId;
            entity.DoctorTypeId = dto.DoctorTypeId;

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
