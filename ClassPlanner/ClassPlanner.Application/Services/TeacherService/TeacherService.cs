using AutoMapper;
using ClassPlanner.Application.Utils;
using ClassPlanner.Application.Models.TeacherModel;
using ClassPlanner.Application.Models.User;
using ClassPlanner.Application.Services.UserService;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Enums;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassPlanner.Application.Models.TeacherInChargeModel;

namespace ClassPlanner.Application.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ITeacherInChargeRepository _teacherInChargeRepository;
        private readonly IUserService _userService;
        private readonly Notifications _notifications;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, Notifications notifications,
                              IMapper mapper, IUserService userService, ITeacherInChargeRepository teacherInChargeRepository)
        {
            _teacherRepository = teacherRepository;
            _teacherInChargeRepository = teacherInChargeRepository;
            _notifications = notifications;
            _mapper = mapper;
            _userService = userService;

        }

        #region Teacher
        public async Task CreateTeacher(TeacherRequestDTO request)
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

        public async Task DeleteTeacher(Guid id)
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

        public async Task UpdateTeacher(TeacherRequestDTO request)
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

        public async Task<TeacherResponseDTO> GetTeacherById(Guid id)
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

        public IList<TeacherResponseDTO> GetAllTeachers()
        {
            var teacher = _teacherRepository.GetAll();
            return _mapper.Map<IList<TeacherResponseDTO>>(teacher);
        }

        public IList<TeacherResponseDTO> GetAllActiveTeachers()
        {
            var teacher = _teacherRepository.GetAllActives();
            return _mapper.Map<IList<TeacherResponseDTO>>(teacher);
        }

        #endregion

        #region TeacherInCharge
        public async Task CreateTeacherInCharge(TeacherInChargeRequestDTO request)
        {
            var teacherInCharge = new TeacherInCharge(request.StudentsClassId, request.TeacherId);
            await _teacherInChargeRepository.Create(teacherInCharge);
        }

        public async Task DeleteTeacherInCharge(Guid id)
        {
            if (_teacherInChargeRepository.EntityExists(id))
            {
                var teacherInCharge = await _teacherInChargeRepository.GetById(id);
                teacherInCharge.Disable();
                await _teacherInChargeRepository.Update(id, teacherInCharge);
            }

            else
            {
                _notifications.AddNotification("Not Found", "O vínculo informado não existe!");
            }

            return;
        }

        public async Task UpdateTeacherInCharge(TeacherInChargeRequestDTO request)
        {
            if (_teacherInChargeRepository.EntityExists(request.Id))
            {
                var teacherInCharge = await _teacherInChargeRepository.GetById(request.Id);
                teacherInCharge.Update(request.StudentsClassId, teacherInCharge.TeacherId, teacherInCharge.Active);
                await _teacherInChargeRepository.Update(request.Id, teacherInCharge);
            }
            else
            {
                _notifications.AddNotification("Not Found", "O vínculo informado não existe!");
            }
        }

        public async Task<TeacherInChargeResponseDTO> GetTeacherInChargeById(Guid id)
        {
            if (_teacherInChargeRepository.EntityExists(id))
            {
                var teacher = await _teacherRepository.GetById(id);
                return _mapper.Map<TeacherInChargeResponseDTO>(teacher);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O vínculo informado não existe!");
            }

            return null;
        }

        public async Task<TeacherInChargeResponseDTO> GetTeacherInChargeByClassId(Guid id)
        {
            if (_teacherInChargeRepository.EntityExists(id))
            {
                var teacherInCharge = _teacherInChargeRepository.GetTeacherInChargeByClassId(id);
                return _mapper.Map<TeacherInChargeResponseDTO>(teacherInCharge);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O vínculo informado não existe!");
            }

            return null;
        }

        public IList<TeacherInChargeResponseDTO> GetAllTeachersInCharge()
        {
            var teacherInCharge = _teacherInChargeRepository.GetAll();
            return _mapper.Map<IList<TeacherInChargeResponseDTO>>(teacherInCharge);
        }

        public IList<TeacherInChargeResponseDTO> GetAllActiveTeachersInCharge()
        {
            var teacherInCharge = _teacherRepository.GetAllActives();
            return _mapper.Map<IList<TeacherInChargeResponseDTO>>(teacherInCharge);
        }

        public IList<TeacherInChargeResponseDTO> GetAllTeachersInChargeAndClasses()
        {
            var teacherInCharge = _teacherInChargeRepository.GetAllTeachersInChargeAndClasses();
            return _mapper.Map<IList<TeacherInChargeResponseDTO>>(teacherInCharge);
        }
        #endregion
    }
}