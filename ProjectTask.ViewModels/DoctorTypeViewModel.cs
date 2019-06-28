using ProjectTask.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTask.ViewModels
{
    public class DoctorTypeViewModel
    {
        public DoctorTypeViewModel(DoctorType entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                Name = entity.Name;
            }
        }

        public DoctorTypeViewModel()
        {

        }

        public int Id { get; set; }

        [DisplayName("Наименование специальности")]
        public string Name { get; set; }
    }
}
