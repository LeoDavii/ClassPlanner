using System;

namespace ClassPlanner.Domain.Entities
{
    public class EnrolledStudent : BaseEntity
    {
        protected EnrolledStudent()
        {
        }

        public EnrolledStudent(Guid studentsClassId, Guid studentId, double value, int registration)
        {
            StudentsClassId = studentsClassId;
            StudentId = studentId;
            Value = value;
            RegistrationId = registration;
            Active = true;
            CreationDate = DateTime.Now;
        }

        public void Update (Guid studentsClassId, Guid studentId, double value, bool active)
        {
            StudentsClassId = studentsClassId;
            StudentId = studentId;
            Value = value;
            Active = active;
            AlterationDate = DateTime.Now;
        }

        public Guid StudentsClassId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public double Value { get; protected set; }
        public int RegistrationId { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public virtual StudentsClass StudentsClass { get; protected set; }
        public virtual Student Student { get; protected set; }
    }
}
