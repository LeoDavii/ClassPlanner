using ClassPlanner.Application.Models.TeacherInChargeModel;
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
        #region Teacher
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherRequestDTO request)
        {
            await _teacherService.CreateTeacher(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] Guid id)
        {
            await _teacherService.DeleteTeacher(id);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateTeacher/{id}")]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherRequestDTO request)
        {
            await _teacherService.UpdateTeacher(request);
            return NoContent();
        }

        [HttpGet]
        [Route ("AllTeachers")]
        public IList<TeacherResponseDTO> GetAllTeachers()
        {
            return _teacherService.GetAllTeachers();
        }

        [HttpGet]
        [Route("activeTeachers")]
        public IList<TeacherResponseDTO> GetAllActiveTeachers()
        {
            return _teacherService.GetAllActiveTeachers();
        }

        [HttpGet]
        [Route("GetTeacher/{id}")]
        public async Task<TeacherResponseDTO> GetTeacherById([FromRoute] Guid id)
        {
            return await _teacherService.GetTeacherById(id);
        }
        #endregion

        #region TeacherInCharge
        [HttpPost]
        public async Task<IActionResult> CreateTeacherInCharge([FromBody] TeacherInChargeRequestDTO request)
        {
            await _teacherService.CreateTeacherInCharge(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteTeacherInCharge/{id}")]
        public async Task<IActionResult> DeleteTeacherInCharge([FromRoute] Guid id)
        {
            await _teacherService.DeleteTeacherInCharge(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherInCharge([FromBody] TeacherInChargeRequestDTO request)
        {
            await _teacherService.UpdateTeacherInCharge(request);
            return NoContent();
        }

        [HttpGet]
        [Route("GetTeacherInCharge/{id}")]
        Task<TeacherInChargeResponseDTO> GetTeacherInChargeById([FromRoute] Guid id)
        {
            return _teacherService.GetTeacherInChargeById(id);
        }

        [HttpGet]
        [Route("TeacherInChargeByClassId/{id}")]
        public Task<TeacherInChargeResponseDTO> GetTeacherInChargeByClassId([FromRoute] Guid id)
        {
            return _teacherService.GetTeacherInChargeByClassId(id);
        }

        [HttpGet]
        [Route ("AllTeachersInCharge")]
        public IList<TeacherInChargeResponseDTO> GetAllTeachersInCharge()
        {
            return _teacherService.GetAllTeachersInCharge();
        }

        [HttpGet]
        [Route("activeTeachersInCharge")]
        public IList<TeacherInChargeResponseDTO> GetAllActiveTeachersInCharge()
        {
            return _teacherService.GetAllActiveTeachersInCharge();
        }

        [HttpGet]
        [Route("TeachersInChargeAndClasses")]
        public IList<TeacherInChargeResponseDTO> GetAllTeachersInChargeAndClasses()
        {
            return _teacherService.GetAllTeachersInChargeAndClasses();
        }
#endregion
    }
}
