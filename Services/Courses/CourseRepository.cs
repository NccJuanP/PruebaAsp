using System.Reflection;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;

namespace prueba.Services.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly pruebaContext _context;
        public CourseRepository(pruebaContext context)
        {
            _context = context;
        }
        //cuerpo de la funcion para crear un curso
        public Course CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            Course course1 = _context.Courses.Include(t => t.Teacher).FirstOrDefault(u => u.Id == course.Id);
            return course1;
        }

        //cuerpo de la funcion para obtener todos los cursos
        public List<Course> GetAllCourses()
        {
            return _context.Courses.Include(u => u.Teacher).ToList();
        }

        //cuerpo de la funcion para obtener un curso por id
        public Course? GetCourseById(int id)
        {
            return _context.Courses.Include(u => u.Teacher).FirstOrDefault(u => u.Id == id);
        }

        //cuerpo de la funcion para actualizar un curso
        public Course UpdateCourse(Course course, int id)
        {
            if (course.Id != id)
            {
                return null;
            }

            if (_context.Courses.Find(id) == null)
            {
                return null;
            }

            Course oldCourse = _context.Courses.Find(id);

            //recorremos el objeto verificando que propiedades son nulas y cuales no
            foreach (PropertyInfo property in course.GetType().GetProperties())
            {   
                if (property.GetValue(course) != null)
                {   
                Console.WriteLine("propiedad: " +  property + " valor: " + property.GetValue(course));
                    property.SetValue(oldCourse, property.GetValue(course));
                }
            }

            _context.Courses.Update(oldCourse);
            _context.SaveChanges();
            Course course1 = _context.Courses.Include(t => t.Teacher).FirstOrDefault(u => u.Id == course.Id);
            return course1;
        }
    }
}