using prueba.Services.Teachers;
using prueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Teachers
{
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //Obtener todos los profesores
        [HttpGet]
        [Route("api/teachers")]
        public IActionResult GetAllTeachers(){
            try{
                return Ok(_teacherRepository.GetAllTeachers());
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Obtener profesor por Id
        [HttpGet]
        [Route("api/teachers/{id}")]
        public IActionResult GetTeacherById(int id){
            try{
                return Ok(_teacherRepository.GetTeacherById(id));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Obtener todos los cursos que pertenecen a un profesor por Id
        [HttpGet]
        [Route("api/teachers/{id}/courses")]
        public IActionResult GetCoursesByTeacherId(int id){
            try{
                return Ok(_teacherRepository.GetCoursesByTeacherId(id));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}