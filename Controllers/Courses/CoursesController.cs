using prueba.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Courses
{
    [ApiController]
    public class CoursesController : ControllerBase
    {  
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //Obtener todos los cursos en la base de datos
        [HttpGet]
        [Route("api/courses")]
        public IActionResult GetAllCourses(){
            try{
                return Ok(_courseRepository.GetAllCourses());
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Obtener curso por Id
        [HttpGet]
        [Route("api/courses/{id}")]
        public IActionResult GetCourseById(int id){
            try{
                return Ok(_courseRepository.GetCourseById(id));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        
    }
}