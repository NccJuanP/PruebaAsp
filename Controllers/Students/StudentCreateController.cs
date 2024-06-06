using prueba.Services.Students;
using Microsoft.AspNetCore.Mvc;
using prueba.Models;

namespace prueba.Controllers.Students
{
    [ApiController]
    public class StudentCreateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        
        public StudentCreateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //Crear un estudiante
        [HttpPost]
        [Route("api/students")]
        public IActionResult CreateStudent(Student student){
            try{
                return Ok(_studentRepository.CreateStudent(student));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}