using ClassPlanner.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Application.Services.UserService
{
    public interface IUserService
    {
        Task Create(UserRequestDTO request);
        Task Delete(Guid id);
        Task Update(UserRequestDTO request);
        Task<UserReponseDTO> GetById(Guid id);
        IList<UserReponseDTO> GetAll();
        IList<UserReponseDTO> GetAllActives();
    }
}
