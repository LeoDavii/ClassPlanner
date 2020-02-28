using System;

namespace ClassPlanner.Application.Models.EnrolledStudentModel
{
    public abstract class EnrolledStudentBaseDTO
    {
        public Guid StudentId { get; set; }
        public Guid StudentsClassId { get; set; }
        public double Value { get; protected set; }
        public bool Active { get; set; }
        public int RegistrationId { get; set; }
    }
}
