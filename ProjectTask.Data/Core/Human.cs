using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Core
{
    public abstract class Human : Entity
    {
        public string IIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
