using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Models
{
    public class Visit : Entity
    {
        public virtual Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        public virtual DoctorType DoctorType { get; set; }
        public int DoctorTypeId { get; set; }

        public virtual Pacient Pacient { get; set; }
        public int PacientId { get; set; }

        public string Diagnosis { get; set; }

        public string Complaints { get; set; }

        public DateTime VisitDate { get; set; }
    }
}
