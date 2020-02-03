using ClassPlanner.Application.Models.StudentModel;
using ClassPlanner.Application.Notification;
using ClassPlanner.Application.Services.StudentService;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Models.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepositoy;
        private readonly Notifications _notifications;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepositoy = studentRepository;
        }

        public async Task Create(StudentRequestDTO request)
        {
            var student = new Student(request.Name);
            await _studentRepositoy.Create(student);
        }

        public async Task Delete(Guid id)
        {
            if (await _studentRepositoy.EntityExists(id))
            {
                var student = await _studentRepositoy.GetById(id);
                student.Disable();
                await _studentRepositoy.Update(id, student);
            }
            else _notifications.AddNotification("NotFound", "O estudante informado não existe!");
        }

        public async Task Update(StudentRequestDTO request)
        {
            if (await _studentRepositoy.EntityExists(request.Id))
            {
                var student = await _studentRepositoy.GetById(request.Id);
                student.Update(request.Name);
                await _studentRepositoy.Update(student.Id, student);
            }
            else _notifications.AddNotification("NotFound", "O estudante informado não existe!");
        }

        public async Task<StudentResponseDTO> GetById(Guid id)
        {
            if (await _studentRepositoy.EntityExists(id))
            {
                var student = await _studentRepositoy.GetById(id);
                return new StudentResponseDTO { Name = student.Name, Id = student.Id, Active = student.Active };
            }
            else _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            return null;
        }

        public async Task<IList<StudentResponseDTO>> GetAll()
        {
            var students = _studentRepositoy.GetAll().ToList();
            return students.Select(s => new StudentResponseDTO()
            {
                Id = s.Id,
                Active = s.Active,
                Name = s.Name,
            }).ToList();
        }
    }
}
