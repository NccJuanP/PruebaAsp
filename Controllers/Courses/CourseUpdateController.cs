using prueba.Models;
using prueba.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Courses
{
    [ApiController]
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseUpdateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //Actualizar curso
        [HttpPut]
        [Route("api/courses/{id}")]
        public IActionResult UpdateCourse(int id, Course course){
            try{
                var user = _courseRepository.UpdateCourse(course, id);
                if(user == null){
                    return BadRequest("Ha ocurrido un error con los IDS comprobar y volver a probar");
                }
                return Ok(user);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}