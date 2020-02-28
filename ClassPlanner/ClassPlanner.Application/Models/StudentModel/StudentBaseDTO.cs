using System;

namespace ClassPlanner.Application.Models.StudentModel
{
    public abstract class StudentBaseDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public bool PrivateStudent {get; set;}
        public bool Active { get; set; }
        public Guid Id { get; set; }
    }
}
