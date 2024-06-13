using prueba.Models;
using prueba.Services.Teachers;
using Microsoft.AspNetCore.Mvc;
using prueba.Dtos;

namespace prueba.Controllers.Teachers
{
    [ApiController]
    public class TeacherUpdateController : ControllerBase
    {

        private readonly ITeacherRepository _teacherRepository;

        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //Actualizar un profesor
        [HttpPut]
        [Route("api/teachers/{id}")]
        public IActionResult UpdateTeacher(int id, TeacherDto teacher)
        {
            try{
                var user = _teacherRepository.UpdateTeacher(teacher, id);
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