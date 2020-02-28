using ClassPlanner.Application.Models.StudenstClassModel;
using ClassPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.StudentClassService
{
    public interface IStudentsClassService
    {
        Task Create(StudentsClassRequestDTO request);
        Task Delete(Guid id);
        Task Update(StudentsClassRequestDTO request);
        Task<StudentsClassResponseDTO> GetById(Guid id);
        IList<StudentsClassResponseDTO> GetAll();
        IList<StudentsClassResponseDTO> GetAllActives();
        IList<StudentsClassResponseDTO> GetAllClassesWithStudentsAndTeacher();
        StudentsClassResponseDTO GetStudentsClassWithStudentsAndTeacher(Guid id);
    }
}
