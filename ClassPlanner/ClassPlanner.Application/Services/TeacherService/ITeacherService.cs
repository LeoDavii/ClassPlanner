using ClassPlanner.Application.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.TeacherService
{
    public interface ITeacherService
    {
        Task Create(TeacherRequestDTO request);
        Task Delete(Guid id);
        Task Update(TeacherRequestDTO request);
        Task<TeacherResponseDTO> GetById(Guid id);
        IList<TeacherResponseDTO> GetAll();
        IList<TeacherResponseDTO> GetAllActives();
    }
}
