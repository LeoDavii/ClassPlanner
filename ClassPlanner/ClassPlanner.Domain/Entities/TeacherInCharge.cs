using System;
using System.Collections.Generic;

namespace ClassPlanner.Domain.Entities
{
    public class TeacherInCharge : BaseEntity
    {
        protected TeacherInCharge()
        {
        }

        public TeacherInCharge(Guid studentsClassId, Guid teacherId)
        {
            StudentsClassId = studentsClassId;
            TeacherId = teacherId;
            Active = true;
            CreationDate = DateTime.Now;
        }

        public void Update(Guid studentsClassId, Guid teacherId, bool active)
        {
            StudentsClassId = studentsClassId;
            TeacherId = teacherId;
            Active = active;
            AlterationDate = DateTime.Now;
        }

        public Guid StudentsClassId { get; protected set; }
        public Guid TeacherId { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public virtual StudentsClass StudentsClass {get; protected set;}
        public virtual Teacher Teacher { get; protected set; }
    }
}