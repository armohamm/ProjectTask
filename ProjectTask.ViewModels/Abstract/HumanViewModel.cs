using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTask.ViewModels.Abstract
{
    public abstract class HumanViewModel : EntityViewModel
    {
        [Display(Name = "ИИН")]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "ИИН не действителен. ИИН должен содержать 12 цифр. Пример: 123456123456")]
        [Required(ErrorMessage ="Заполните ИИН")]
        public string IIN { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Заполните Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Заполните Отчество")]
        public string LastName { get; set; }

        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        [RegularExpression(@"^[+]\d{11}$", ErrorMessage = "Номер телефон не действителен. Пример: +77051234567")]
        public string PhoneNumber { get; set; }
    }
}
