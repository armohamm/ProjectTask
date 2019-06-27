using ProjectTask.Data.Models;
using ProjectTask.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.ViewModels
{
    public class PacientViewModel : HumanViewModel
    {
        public ICollection<VisitViewModel> Visits { get; set; } = new List<VisitViewModel>();

        public PacientViewModel(Pacient pacient)
        {
            if (pacient != null)
            {
                Id = pacient.Id;
                IIN = pacient.IIN;
                FirstName = pacient.FirstName;
                LastName = pacient.LastName;
                SurName = pacient.SurName;
                Address = pacient.Address;
                PhoneNumber = pacient.PhoneNumber;
            }
        }
        public PacientViewModel()
        {
        }
    }
}
