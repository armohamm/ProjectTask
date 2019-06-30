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
            if (!UnitOfWork.Select<DoctorType>().Any())
            {
                var dto = new DoctorType()
                {
                    Name = "Лор",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<DoctorType>(dto);
                dto = new DoctorType()
                {
                    Name = "Окулист",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<DoctorType>(dto);
            }
            if (!UnitOfWork.Select<Doctor>().Any())
            {
                var doctor = new Doctor()
                {
                    Address = "Нурсултан",
                    IIN = "123123456456",
                    FirstName = "Айболит",
                    LastName = "Доктор1",
                    SurName = "Попов",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Doctor>(doctor);

                doctor = new Doctor()
                {
                    Address = "Нурсултан",
                    IIN = "123123456456",
                    FirstName = "Айболат",
                    LastName = "Доктор2",
                    SurName = "Смирнов",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Doctor>(doctor);
            }


            if (!UnitOfWork.Select<Pacient>().Any())
            {
                var dto = new Pacient()
                {
                    Address = "Нурсултан",
                    IIN = "123123456456",
                    FirstName = "Дастан",
                    LastName = "Пациент",
                    SurName = "Пациент1",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Pacient>(dto);
                dto = new Pacient()
                {
                    Address = "Нурсултан",
                    IIN = "123123456456",
                    FirstName = "Айдана",
                    LastName = "Пациентова",
                    SurName = "Пациент2",
                    LastEditedAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                };

                UnitOfWork.Insert<Pacient>(dto);
            }

            await UnitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
}
