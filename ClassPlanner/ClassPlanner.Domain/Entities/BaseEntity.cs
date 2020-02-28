using System;

namespace ClassPlanner.Domain.Entities
{
    public abstract class BaseEntity
    {
        public bool Active { get; protected set; }
        public Guid Id { get; protected set; }

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