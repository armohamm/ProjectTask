using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Models
{
    public class DoctorType : Entity
    {
        public string Name { get; set; }

        public ICollection<RelDoctorDoctorType> RelDoctorDoctorTypes { get; set; }
    }
}
