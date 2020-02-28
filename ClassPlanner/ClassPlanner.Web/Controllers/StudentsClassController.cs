using ClassPlanner.Application.Models.StudenstClassModel;
using ClassPlanner.Application.Services.StudentClassService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsClassController : Controller
    {
        private readonly IStudentsClassService _studentsClassService;

        public StudentsClassController(IStudentsClassService studentsClassService)
        {
            _studentsClassService = studentsClassService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentsClassRequestDTO request)
        {
            await _studentsClassService.Create(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentsClassRequestDTO request)
        {
            await _studentsClassService.Update(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _studentsClassService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IList<StudentsClassResponseDTO> GetAll()
        {
            return _studentsClassService.GetAll();
        }

        [HttpGet]
        [Route("actives")]
        public IList<StudentsClassResponseDTO> GetAllActives()
        {
            return _studentsClassService.GetAllActives();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<StudentsClassResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _studentsClassService.GetById(id);
        }

        [HttpGet]
        [Route("{StudentsAndTeacher}/{id}")]
        public async Task<StudentsClassResponseDTO> GetStudentsClassWithStudentsAndTeacher(Guid id)
        {
            return _studentsClassService.GetStudentsClassWithStudentsAndTeacher(id);
        }

    }
}
