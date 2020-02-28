using AutoMapper;
using ClassPlanner.Application.ErrorsNotifications;
using ClassPlanner.Application.Models.User;
using ClassPlanner.Application.Services.UserService;
using ClassPlanner.Domain.Entities;
using ClassPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.StudentService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly Notifications _notifications;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, Notifications notifications,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _notifications = notifications;
            _mapper = mapper;
        }

        public async Task Create(UserRequestDTO request)
        {
            var firstPassword = GenerateFirstPassword(request.Name);
            var user = new User(request.Name, request.EmailLogin, firstPassword, request.Role);
            await _userRepository.Create(user);
        }

        public async Task Delete(Guid id)
        {
            if (_userRepository.EntityExists(id))
            {
                var student = await _userRepository.GetById(id);
                student.Disable();
                await _userRepository.Update(id, student);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return;
        }

        public async Task Update(UserRequestDTO request)
        {
            if (_userRepository.EntityExists(request.Id))
            {
                var user = await _userRepository.GetById(request.Id);
                user.Update(request.Name, request.EmailLogin, request.Password, request.Role, request.Active);
                await _userRepository.Update(user.Id, user);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return;
        }

        public async Task<UserReponseDTO> GetById(Guid id)
        {
            if (_userRepository.EntityExists(id))
            {
                var user = await _userRepository.GetById(id);
                return _mapper.Map<UserReponseDTO>(user);
            }
            else
            {
                _notifications.AddNotification("NotFound", "O estudante informado não existe!");
            }

            return null;
        }

        public IList<UserReponseDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IList<UserReponseDTO>>(users);
        }

        public IList<UserReponseDTO> GetAllActives()
        {
            var users = _userRepository.GetAllActives();
            return _mapper.Map<IList<UserReponseDTO>>(users);
        }

        private string GenerateFirstPassword(string userName)
        {
            return String.Format("{0:X}", userName.GetHashCode());
        }
    }
}
