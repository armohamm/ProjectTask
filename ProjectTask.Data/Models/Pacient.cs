using ProjectTask.Data.Core;
using System.Collections.Generic;

namespace ProjectTask.Data.Models
{
    public class Pacient : Human
    {
       public ICollection<Visit> Visits { get; set; }
    }
}
