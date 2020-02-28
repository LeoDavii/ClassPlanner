using ClassPlanner.Application.Models.EnrolledStudentModel;
using ClassPlanner.Domain.Entities;
using System.Collections.Generic;

namespace ClassPlanner.Application.Models.StudenstClassModel
{
    public class StudentsClassResponseDTO : StudentsClassBaseDTO
    {
        public List<EnrolledStudentResponseDTO> EnrolledStudents { get; set; }
        public TeacherInCharge TeacherInCharge { get; set; }
    }
}
