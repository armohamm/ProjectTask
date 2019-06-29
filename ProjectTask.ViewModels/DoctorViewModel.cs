using ProjectTask.Data.Models;
using ProjectTask.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTask.ViewModels
{

    public class DoctorViewModel : HumanViewModel
    {
        public ICollection<int> DoctorTypeIds { get; set; } = new List<int>();

        public DoctorViewModel(Doctor entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                IIN = entity.IIN;
                FirstName = entity.FirstName;
                LastName = entity.LastName;
                SurName = entity.SurName;
                PhoneNumber = entity.PhoneNumber;
                Address = entity.Address;
                if (entity.RelDoctorDoctorTypes.Any())
                {
                    DoctorTypeIds = new List<int>(entity.RelDoctorDoctorTypes.Select(x => x.DoctorTypeId));
                }
            }
        }
        public DoctorViewModel()
        {
        }
    }
}
