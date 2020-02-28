using AutoMapper;
using ClassPlanner.Application.Utils;
using ClassPlanner.Application.Models.StudentModel;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepositoy;
        private readonly Notifications _notifications;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, Notifications notifications,
                              IMapper mapper)
        {
            _studentRepositoy = studentRepository;
            _notifications = notifications;
            _mapper = mapper;
        }

        public async Task Create(StudentRequestDTO request)
        {
            var student = new Student(request.Name, request.PrivateStudent, request.Address, 
                                      request.Contact, request.CPF);
            await _studentRepositoy.Create(student);
        }

        public async Task Delete(Guid id)
        {
            if (_studentRepositoy.EntityExists(id))
            {
                var student = await _studentRepositoy.GetById(id);
                student.Disable();
                await _studentRepositoy.Update(id, student);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return;
        }

        public async Task Update(StudentRequestDTO request)
        {
            if (_studentRepositoy.EntityExists(request.Id))
            {
                var student = await _studentRepositoy.GetById(request.Id);
                student.Update(request.Name, request.PrivateStudent, request.Address, 
                               request.Contact, request.CPF);

                await _studentRepositoy.Update(student.Id, student);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return;
        }

        public async Task<StudentResponseDTO> GetById(Guid id)
        {
            if (_studentRepositoy.EntityExists(id))
            {
                var student = await _studentRepositoy.GetById(id);
                return _mapper.Map<StudentResponseDTO>(student);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return null;
        }

        public IList<StudentResponseDTO> GetAll()
        {
            var students = _studentRepositoy.GetAll();
            return _mapper.Map<IList<StudentResponseDTO>>(students);
        }

        public IList<StudentResponseDTO> GetAllActives()
        {
            var students = _studentRepositoy.GetAllActives();
            return _mapper.Map<IList<StudentResponseDTO>>(students);
        }
    }
}
