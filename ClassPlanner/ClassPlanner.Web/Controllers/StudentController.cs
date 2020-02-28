using ClassPlanner.Application.Models.StudentModel;
using ClassPlanner.Application.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController (IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] StudentRequestDTO request)
        {
            await _studentService.Create(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update ([FromBody] StudentRequestDTO request)
        {
            await _studentService.Update(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _studentService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IList<StudentResponseDTO> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet]
        [Route("actives")]
        public IList<StudentResponseDTO> GetAllActives()
        {
            return _studentService.GetAllActives();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<StudentResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _studentService.GetById(id);
        }
    }
}
