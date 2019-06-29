using ProjectTask.Data.Core;
using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.DatabaseSeed
{
    public class DataSeeder : ISeed
    {
        private IUnitOfWork UnitOfWork { get; }

        public DataSeeder(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public async Task SeedAsync()
        {
            if (!UnitOfWork.Select<Doctor>().Any())
            {
                var doctor = new Doctor()
                {
                    Address = "Nur-Sultan",
                    IIN = "123123456456",
                    FirstName = "Aibolit",
                    LastName = "Doctor",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Doctor>(doctor);
            }
            if (!UnitOfWork.Select<DoctorType>().Any())
            {
                var dto = new DoctorType()
                {
                    Name = "Все может",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<DoctorType>(dto);
            }

            if (!UnitOfWork.Select<Pacient>().Any())
            {
                var dto = new Pacient()
                {
                    Address = "Nur-Sultan",
                    IIN = "123123456456",
                    FirstName = "Bolat",
                    LastName = "Pacient",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Pacient>(dto);
            }

            await UnitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
}
