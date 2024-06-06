using prueba.Models;
namespace prueba.Services.Enrollments
{
    public interface IEnrollmentRepository
    {
        //Funcion para listar las matriculas
        List<Enrollment> GetAllEnrollments();

        //Funcion para listar una matricula por id
        Enrollment? GetEnrrollmentById(int id);

        //Funcion para crear una matricula
        Enrollment CreateEnrrollment(Enrollment enrollment);

        //Funcion para actualizar una matricula
        Enrollment UpdateEnrrollment(Enrollment enrollment, int id);

        //Funcion para Listar las matriculas por fecha especifica
        List<Enrollment> GetEnrollmentsByDate(DateOnly date);
    }
}