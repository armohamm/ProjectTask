using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Models
{
    public class Doctor : Human
    {
        public ICollection<RelDoctorDoctorType> RelDoctorDoctorTypes { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
