using prueba.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers.Enrrollements
{
    [ApiController]
    public class enrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public enrollmentsController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        //Obtener todas las matriculas
        [HttpGet]
        [Route("api/enrollments")]
        public IActionResult GetAllenrollments(){
            try
            {
                return Ok(_enrollmentRepository.GetAllEnrollments());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Obtener matricula por Id
        [HttpGet]
        [Route("api/enrollments/{id}")]
        public IActionResult GetEnrrollmentById(int id){
            try
            {
                return Ok(_enrollmentRepository.GetEnrrollmentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Listar las matriculas por fecha
        [HttpGet]
        [Route("api/enrollments/{date}/date")]
        public IActionResult GetEnrollmentsByDate(DateOnly date){
            try
            {
                return Ok(_enrollmentRepository.GetEnrollmentsByDate(date));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}