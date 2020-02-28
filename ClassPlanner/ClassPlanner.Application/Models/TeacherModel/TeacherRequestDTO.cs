using ClassPlanner.Domain.Entities;
using System.Collections.Generic;

namespace ClassPlanner.Application.Models.TeacherModel
{
    public class TeacherRequestDTO : TeacherBaseDTO
    {
        public string EmailLogin { get; set; }
    }
}
