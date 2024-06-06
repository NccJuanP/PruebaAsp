using prueba.Services.Students;
using prueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Students
{
    [ApiController]
    public class StudentUpdateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentUpdateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //Actualizar un estudiante

        [HttpPut]
        [Route("api/students/{id}")]
        public IActionResult UpdateStudent(int id, Student student){
            try{
                var user = _studentRepository.UpdateStudent(student, id);
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