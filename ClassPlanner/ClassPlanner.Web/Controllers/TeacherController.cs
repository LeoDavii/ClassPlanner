using ClassPlanner.Application.Models.TeacherModel;
using ClassPlanner.Application.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherRequestDTO request)
        {
            await _teacherService.Create(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TeacherRequestDTO request)
        {
            await _teacherService.Update(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _teacherService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IList<TeacherResponseDTO> GetAll()
        {
            return _teacherService.GetAll();
        }

        [HttpGet]
        [Route("actives")]
        public IList<TeacherResponseDTO> GetAllActives()
        {
            return _teacherService.GetAllActives();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TeacherResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _teacherService.GetById(id);
        }
    }
}
