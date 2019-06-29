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
    public class DoctorService : CRUDServiceBase<Doctor, DoctorViewModel>
    {
        public DoctorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override DoctorViewModel GetDTO(int id)
        {
            return GetActualRecords()
                .Include(x => x.RelDoctorDoctorTypes)
                .Where(x => x.Id == id)
                .Select(x => new DoctorViewModel(x))
                .FirstOrDefault();
        }

        public override IEnumerable<DoctorViewModel> GetDTOs()
        {
            return GetActualRecords().Select(x => new DoctorViewModel(x));
        }

        public override async Task SaveAsync(DoctorViewModel viewModel)
        {
            await DoInTransactionScope(Save, viewModel);
        }

        private async Task Save(DoctorViewModel dto)
        {
            var entityTuple = GetOrCreateEntity<Doctor>(GetActualRecords().Include(x => x.RelDoctorDoctorTypes), x => x.Id == dto.Id);
            var entity = entityTuple.Item2;

            entity.IIN = dto.IIN;
            entity.LastName = dto.LastName;
            entity.FirstName = dto.FirstName;
            entity.SurName = dto.SurName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Address = dto.Address;
            entity.LastEditedAt = DateTime.Now;

            EditDoctorTypes(entity, dto);

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

        private void EditDoctorTypes(Doctor entity, DoctorViewModel view)
        {
            ICollection<int> selectedDoctorTypeIds = view.DoctorTypeIds;

            var currentDoctorTypeIds = entity.RelDoctorDoctorTypes
                .Where(p => p.DoctorId == entity.Id)
                .ToArray()
                ;

            foreach (var i in currentDoctorTypeIds)
            {
                if (!selectedDoctorTypeIds.Contains(i.DoctorTypeId))
                {
                    entity.RelDoctorDoctorTypes.Remove(i);
                }
            }

            foreach (int i in selectedDoctorTypeIds)
            {
                if (!currentDoctorTypeIds.Any(x => x.DoctorTypeId == i && x.DoctorId == entity.Id))
                {
                    entity.RelDoctorDoctorTypes.Add(new RelDoctorDoctorType
                    {
                        DoctorId = entity.Id,
                        DoctorTypeId = i
                    });
                }
            }
        }
    }
}
