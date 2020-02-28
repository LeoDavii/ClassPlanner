using System;

namespace ClassPlanner.Application.Models.StudenstClassModel
{
    public abstract class StudentsClassBaseDTO
    {
        public string Name { get; set; }
        public bool Active { get; set; } 
        public Guid Id { get; set; }
    }
}
