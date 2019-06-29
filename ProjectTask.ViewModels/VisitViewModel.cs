using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PacientId { get; set; }

        public int DoctorTypeId { get; set; }

        public string Diagnosis { get; set; }

        public string Complaints { get; set; }

        public DateTime VisitDate { get; set; }

        public VisitViewModel()
        { }
        public VisitViewModel(Visit entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                VisitDate = entity.VisitDate;
                Complaints = entity.Complaints;
                Diagnosis = entity.Diagnosis;
                PacientId = entity.PacientId;
                DoctorTypeId = entity.DoctorTypeId;
                DoctorId = entity.DoctorId;
            }
        }
    }
}
