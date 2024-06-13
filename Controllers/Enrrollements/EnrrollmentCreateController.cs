using prueba.Models;
using prueba.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;
using prueba.Services.Emails;

namespace prueba.Controllers.Enrrollements
{
    [ApiController]
    public class EnrrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        //Crear nueva matricula
        [HttpPost]
        [Route("api/enrollments")]
        public IActionResult CreateEnrrollment(Enrollment enrrollment){
            try{
                var user = _enrollmentRepository.CreateEnrrollment(enrrollment);
                EmailsController email = new EmailsController();
                email.CreateEmail(user.Student.Email, user.Student.Names, user.Course.Teacher.Email, user.Course.Teacher.Names, user.Status, user.Course.Name);
                return Ok(user);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}