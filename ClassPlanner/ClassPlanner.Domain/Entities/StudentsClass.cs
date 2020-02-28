using System;
using System.Collections.Generic;

namespace ClassPlanner.Domain.Entities
{
    public class StudentsClass : BaseEntity
    {
        protected StudentsClass()
        {
        }

        public StudentsClass (string name, List<EnrolledStudent> enrolledStudents)
        {
            Name = name;
            EnrolledStudents = enrolledStudents;
            Active = true;
            CreationDate = DateTime.Now;
        }

        public void Update (string name, bool active, List<EnrolledStudent> enrolledStudents)
        {
            Name = name;
            EnrolledStudents = enrolledStudents;
            Active = active;
            AlterationDate = DateTime.Now;
        }

        public string Name { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public virtual List<EnrolledStudent> EnrolledStudents { get; protected set; }
        public virtual TeacherInCharge TeacherInCharge { get; protected set; }
    }
}
