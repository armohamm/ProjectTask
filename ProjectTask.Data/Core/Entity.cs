using System;

namespace ProjectTask.Data.Core
{
    public abstract class Entity <T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastEditedAt { get; set;}
    }

    public abstract class Entity : Entity<int>
    {

    }
}
