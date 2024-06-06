using prueba.Models;

namespace prueba.Services.Students
{
    public interface IStudentRepository
    {
        //Funcion para listar todos los students
        List<Student> GetAllStudents();

        //Funcion para listar un student por id
        Student? GetStudentById(int id);

        //Funcion para crear un student
        Student CreateStudent(Student student);

        //Funcion para actualizar un student
        Student UpdateStudent(Student student, int id);

        //Funcion para listar todas las matriculas de un estudiante por id
        List<Enrollment> GetEnrollmentsByStudentId(int id);

        //Funcion para listar a todos los estudiantes que cumplan años en una fecha especifica
        List<Student> GetStudentsByDate(DateOnly date);
    }
}