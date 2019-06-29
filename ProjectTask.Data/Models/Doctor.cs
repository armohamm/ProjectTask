using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Models
{
    public class Doctor : Human
    {
        public ICollection<RelDoctorDoctorType> RelDoctorDoctorTypes { get; set; } = new List<RelDoctorDoctorType>();

        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
