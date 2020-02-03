using ClassPlanner.Application.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.StudentService
{
    public interface IStudentService
    {
        Task Create(StudentRequestDTO request);
        Task Delete(Guid id);
        Task Update(StudentRequestDTO request);
        Task<StudentResponseDTO> GetById(Guid id);
        Task<IList<StudentResponseDTO>> GetAll();
    }
}
