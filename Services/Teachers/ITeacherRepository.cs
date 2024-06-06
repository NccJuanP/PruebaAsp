using prueba.Models;

namespace prueba.Services.Teachers
{
    public interface ITeacherRepository
    {
        //Funcion para listar todos los profesores
        List<Teacher> GetAllTeachers();

        //Funcion para listar un profesor por id
        Teacher? GetTeacherById(int id);

        //Funcion para crear un profesor
        Teacher CreateTeacher(Teacher teacher);

        //Funcion para actualizar un profesor
        Teacher UpdateTeacher(Teacher teacher, int id);

        //Funcion para listar todos los cursos que pertenecen a un profesor
        List<Course> GetCoursesByTeacherId(int id);
    }
}