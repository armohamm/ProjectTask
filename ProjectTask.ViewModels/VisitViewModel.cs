using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTask.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Доктор")]
        [Required(ErrorMessage = "Выберите врача")]
        public int DoctorId { get; set; }

        [Display(Name = "Пациент")]
        [Required(ErrorMessage = "Выберите пациента")]
        public int PacientId { get; set; }

        [Display(Name = "Специальность доктора")]
        [Required(ErrorMessage = "Выберите специальность врача")]
        public int DoctorTypeId { get; set; }

        [Display(Name ="Диагноз")]
        [Required(ErrorMessage = "Заполните поле Диагноз")]
        public string Diagnosis { get; set; }

        [Display(Name = "Жалобы")]
        [Required(ErrorMessage = "Заполните поле Жалобы")]
        public string Complaints { get; set; }

        [Display(Name = "Дата посещения")]
        [Required(ErrorMessage ="Заполните дату посещения")]
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
