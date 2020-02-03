using System;

namespace ClassPlanner.Application.Models.StudentModel
{
    public abstract class StudentBaseDTO
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid Id { get; set; }
    }
}
