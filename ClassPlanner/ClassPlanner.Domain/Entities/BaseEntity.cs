using System;

namespace ClassPlanner.Domain.Entities
{
    public abstract class BaseEntity
    {
        public bool Active { get; set; }
        public Guid Id { get; set; }

        public void Disable()
        {
            Active = false;
        }

        public void Enable()
        {
            Active = true;
        }
    }
}