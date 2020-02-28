using ClassPlanner.Application.Models.TeacherModel;
using ClassPlanner.Application.Models.User;
using ClassPlanner.Application.Services.TeacherService;
using ClassPlanner.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestDTO request)
        {
            await _userService.Create(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserRequestDTO request)
        {
            await _userService.Update(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IList<UserReponseDTO> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Route("actives")]
        public IList<UserReponseDTO> GetAllActives()
        {
            return _userService.GetAllActives();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserReponseDTO> GetById([FromRoute] Guid id)
        {
            return await _userService.GetById(id);
        }
    }
}
