using AutoMapper;
using ClassPlanner.Application.Utils;
using ClassPlanner.Application.Models.StudenstClassModel;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.StudentClassService
{
    public class StudentsClassService : IStudentsClassService
    {
        private readonly IStudentsClassRepository _studentsClassRepository;
        private readonly Notifications _notifications;
        private readonly IMapper _mapper;

        public StudentsClassService(IStudentsClassRepository studentsClassRepository, Notifications notifications, 
                                    IMapper mapper)
        {
            _studentsClassRepository = studentsClassRepository;
            _notifications = notifications;
            _mapper = mapper;
        }

        public async Task Create(StudentsClassRequestDTO request)
        {
            var studentsClass = new StudentsClass(request.Name, null);
            await _studentsClassRepository.Create(studentsClass);
        }

        public async Task Delete(Guid id)
        {
            if (_studentsClassRepository.EntityExists(id))
            {
                var studentsClass = await _studentsClassRepository.GetById(id);
                studentsClass.Disable();
                await _studentsClassRepository.Update(id, studentsClass);
            }

            else
            {
                _notifications.AddNotification("Not Found", "A classe informada não existe!");
            }

            return;
        }

        public async Task Update(StudentsClassRequestDTO request)
        {
            if (_studentsClassRepository.EntityExists(request.Id))
            {
                var studentsClass = await _studentsClassRepository.GetById(request.Id);
                studentsClass.Update(request.Name, studentsClass.Active, null);
                await _studentsClassRepository.Update(request.Id, studentsClass);
            }
            else
            {
                _notifications.AddNotification("Not Found", "A classe informada não existe!");
            }

            return;
        }

        public async Task<StudentsClassResponseDTO> GetById(Guid id)
        {
            if (_studentsClassRepository.EntityExists(id))
            {
                var studentsClass = await _studentsClassRepository.GetById(id);
                return _mapper.Map<StudentsClassResponseDTO>(studentsClass);
            }
            else
            {
               _notifications.AddNotification("Not Found", "A classe informada não existe!");
            }
            return null;
        }
   
        public IList<StudentsClassResponseDTO> GetAll()
        {
            var studentsClasses = _studentsClassRepository.GetAll();
            return _mapper.Map<IList<StudentsClassResponseDTO>>(studentsClasses);
        }

        public IList<StudentsClassResponseDTO> GetAllActives()
        {
            var studentsClasses = _studentsClassRepository.GetAllActives();
            return _mapper.Map<IList<StudentsClassResponseDTO>>(studentsClasses);
        }

        public IList<StudentsClassResponseDTO> GetAllClassesWithStudentsAndTeacher()
        {
            var studentsClasses = _studentsClassRepository.GetAllClassesWithEnrolledStudentsAndTeacher().ToList();
            return _mapper.Map<IList<StudentsClassResponseDTO>>(studentsClasses);
        }

        public StudentsClassResponseDTO GetStudentsClassWithStudentsAndTeacher(Guid id)
        {
            if (_studentsClassRepository.EntityExists(id))
            {
                var studentsClass = _studentsClassRepository.GetClassWithEnrolledStudentsAndTeacher(id);
                return _mapper.Map<StudentsClassResponseDTO>(studentsClass);
            }
            else
            {
                _notifications.AddNotification("Not Found", "A classe informada não existe!");
            }
            return null;
        }
    }
}
