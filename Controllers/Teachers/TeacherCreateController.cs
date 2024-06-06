using prueba.Models;
using prueba.Data;
using prueba.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Teachers
{
    [ApiController]
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //Crear un profesor
        [HttpPost]
        [Route("api/teachers")]
        public IActionResult CreateTeacher(Teacher teacher){
            try{
                return Ok(_teacherRepository.CreateTeacher(teacher));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}