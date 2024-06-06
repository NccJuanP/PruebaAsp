using prueba.Models;

namespace prueba.Services.Courses
{
    public interface ICourseRepository
    {
        //Funcion para listar los cursos
        List<Course> GetAllCourses();

        //Funcion para listar un curso por id
        Course? GetCourseById(int id);

        //Funcion para crear un curso
        Course CreateCourse(Course course);

        //Funcion para actualizar un curso
        Course UpdateCourse(Course course, int id);
    }
}