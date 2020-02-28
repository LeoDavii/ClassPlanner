using AutoMapper;
using ClassPlanner.Application.ErrorsNotifications;
using ClassPlanner.Application.Models.TeacherModel;
using ClassPlanner.Application.Models.User;
using ClassPlanner.Application.Services.UserService;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Enums;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserService _userService;
        private readonly Notifications _notifications;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, Notifications notifications,
                              IMapper mapper, IUserService userService)
        {
            _teacherRepository = teacherRepository;
            _notifications = notifications;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task Create(TeacherRequestDTO request)
        {
            var teacher = new Teacher(request.Name, request.CPF);
            await _teacherRepository.Create(teacher);
            var user = new UserRequestDTO()
            {
                EmailLogin = request.EmailLogin,
                Name = request.Name,
                Role = (int)Roles.Docente,
            };
            await _userService.Create(user);
            
        }

        public async Task Delete(Guid id)
        {
            if (_teacherRepository.EntityExists(id))
            {
                var teacher = await _teacherRepository.GetById(id);
                teacher.Disable();
                await _teacherRepository.Update(id, teacher);
            }

            else
            {
                _notifications.AddNotification("Not Found", "O professor informado não existe!");
            }

            return;
        }

        public async Task Update(TeacherRequestDTO request)
        {
            if (_teacherRepository.EntityExists(request.Id))
            {
                var teacher = await _teacherRepository.GetById(request.Id);
                teacher.Update(request.Name, teacher.CPF, teacher.Active);
                await _teacherRepository.Update(request.Id, teacher);
            }
            else
            {
                _notifications.AddNotification("Not Found", "O professor informado não existe!");
            }
        }

        public async Task<TeacherResponseDTO> GetById(Guid id)
        {
            if (_teacherRepository.EntityExists(id))
            {
                var teacher = await _teacherRepository.GetById(id);
                return _mapper.Map<TeacherResponseDTO>(teacher);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O professor informado não existe!");
            }

            return null;
        }

        public IList<TeacherResponseDTO> GetAll()
        {
            var teacher = _teacherRepository.GetAll();
            return _mapper.Map<IList<TeacherResponseDTO>>(teacher);
        }

        public IList<TeacherResponseDTO> GetAllActives()
        {
            var teacher = _teacherRepository.GetAllActives();
            return _mapper.Map<IList<TeacherResponseDTO>>(teacher);
        }
    }
}