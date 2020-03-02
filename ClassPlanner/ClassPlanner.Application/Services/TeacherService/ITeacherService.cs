using ClassPlanner.Application.Models.TeacherInChargeModel;
using ClassPlanner.Application.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.TeacherService
{
    public interface ITeacherService
    {
        Task CreateTeacher(TeacherRequestDTO request);
        Task DeleteTeacher(Guid id);
        Task UpdateTeacher(TeacherRequestDTO request);
        Task<TeacherResponseDTO> GetTeacherById(Guid id);
        IList<TeacherResponseDTO> GetAllTeachers();
        IList<TeacherResponseDTO> GetAllActiveTeachers();
        Task CreateTeacherInCharge(TeacherInChargeRequestDTO request);
        Task DeleteTeacherInCharge(Guid id);
        Task UpdateTeacherInCharge(TeacherInChargeRequestDTO request);
        Task<TeacherInChargeResponseDTO> GetTeacherInChargeById(Guid id);
        Task<TeacherInChargeResponseDTO> GetTeacherInChargeByClassId(Guid id);
        IList<TeacherInChargeResponseDTO> GetAllTeachersInCharge();
        IList<TeacherInChargeResponseDTO> GetAllActiveTeachersInCharge();
        IList<TeacherInChargeResponseDTO> GetAllTeachersInChargeAndClasses();
    }
}
