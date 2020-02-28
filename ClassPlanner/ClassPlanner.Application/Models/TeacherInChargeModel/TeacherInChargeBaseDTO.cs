using System;

namespace ClassPlanner.Application.Models.TeacherInChargeModel
{
    public class TeacherInChargeBaseDTO
    {
        public Guid StudentsClassId { get; set; }
        public Guid TeacherId { get; set; }
        public bool Active { get; set; }
    }
}
