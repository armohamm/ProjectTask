using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Models
{
    public class RelDoctorDoctorType
    {
        public virtual  Doctor Doctor { get; set; }
        public virtual DoctorType DoctorType { get; set; }
        public int DoctorId { get; set; }
        public int DoctorTypeId { get; set; }
    }
}
