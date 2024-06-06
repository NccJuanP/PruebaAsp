using prueba.Models;
using prueba.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Courses
{
    [ApiController]
    public class CourseCreateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseCreateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // Crear un nuevo curso
        [HttpPost]
        [Route("api/courses")]
        public IActionResult CreateCourse(Course course){
            try{
                return Ok(_courseRepository.CreateCourse(course));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}