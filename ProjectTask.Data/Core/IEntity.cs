using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTask.Data.Core
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? LastEditedAt { get; set; }
    }
}
