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
    public class PacientService : ServiceBase<Pacient>, IService<PacientViewModel>
    {
        public PacientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public PacientViewModel GetDTO(int id)
        {
            var dbEntity = GetActualRecords().Where(x => x.Id == id).FirstOrDefault();

            return new PacientViewModel(dbEntity);
        }

        public IEnumerable<PacientViewModel> GetDTOs()
        {
            return GetActualRecords().Select(x => new PacientViewModel(x));
        }

        public async Task SaveAsync(PacientViewModel dto)
        {
            await DoInTransactionScope(SaveAsynCore, dto);
        }

        private async Task SaveAsynCore(PacientViewModel dto)
        {
            var entityTuple = GetOrCreateEntity(GetActualRecords(), x => x.Id == dto.Id);

            var entity = entityTuple.Item2;

            entity.Address = dto.Address;
            entity.FirstName = dto.FirstName;
            entity.IIN = dto.IIN;
            entity.LastEditedAt = DateTime.Now;
            entity.LastName = dto.LastName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.SurName = dto.SurName;

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
