using prueba.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Students
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        //Obtener todos los students
        [HttpGet]
        [Route("api/students")]
        public IActionResult GetAllStudents(){
            try{
                return Ok(_studentRepository.GetAllStudents());
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Obtener Student por Id
        [HttpGet]
        [Route("api/students/{id}")]
        public IActionResult GetStudentById(int id){
            try{
                return Ok(_studentRepository.GetStudentById(id));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Listar todas las matriculas de un estudiante
        [HttpGet]
        [Route("api/students/{id}/enrollments")]
        public IActionResult GetEnrollmentsByStudentId(int id){
            try{
                return Ok(_studentRepository.GetEnrollmentsByStudentId(id));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        //Listar a todos los estudiantes que cumplan años en una fecha especifica
        [HttpGet]
        [Route("api/students/{date}/date")]
        public IActionResult GetStudentsByDate(DateOnly date){
            try{
                return Ok(_studentRepository.GetStudentsByDate(date));
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}