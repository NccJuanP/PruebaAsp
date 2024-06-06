using prueba.Models;
using prueba.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Enrrollements
{
    [ApiController]
    public class EnrrollmentUpdateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        //Actualizar matricula
        [HttpPut]
        [Route("api/enrollments/{id}")]
        public IActionResult UpdateEnrrollment(int id, Enrollment enrrollment){
            try{
                var user = _enrollmentRepository.UpdateEnrrollment(enrrollment, id);
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