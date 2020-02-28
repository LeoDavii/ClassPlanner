using ClassPlanner.Domain.Entities;
using System.Collections.Generic;

namespace ClassPlanner.Application.Models.TeacherInChargeModel
{
    public class TeacherInChargeResponseDTO : TeacherInChargeBaseDTO
    {
        public virtual List<StudentsClass> StudentsClasses { get; set; }
    }
}
