using prueba.Models;
using prueba.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using prueba.Dtos;

namespace prueba.Services.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {   
        private readonly pruebaContext _context;
        private readonly IMapper _mapper;
        public TeacherRepository(pruebaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Cuerpo de la funcion para crear un profesor
        public Teacher CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        //Cuerpo de la funcion para obtener todos los profesores
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        //Cuerpo de la funcion para listar todos los cursos que pertenecen a un profesor
        public List<Course> GetCoursesByTeacherId(int id)
        {
            return _context.Courses.Where(u => u.TeacherId == id).ToList();
        }

        //Cuerpo de la funcion para obtener un profesor por id
        public Teacher? GetTeacherById(int id)
        {
            return _context.Teachers.Find(id);
        }

        //Cuerpo de la funcion para actualizar un profesor
        public Teacher UpdateTeacher(TeacherDto teacher, int id)
        {
            if (teacher.Id != id)
            {
                return null;
            }

            if (_context.Teachers.Find(id) == null)
            {
                return null;
            }
            
            Teacher oldTeacher = _context.Teachers.Find(id);

            _mapper.Map(teacher, oldTeacher);

            //recorremos el objeto verificando que propiedades son nulas y cuales no
            /* foreach (PropertyInfo property in teacher.GetType().GetProperties())
            {
                if (property.GetValue(teacher) != null)
                {   
                    property.SetValue(oldTeacher, property.GetValue(teacher));
                }
            } */

            _context.SaveChanges();
            Teacher newTeacher = _context.Teachers.Include(c => c.Courses).FirstOrDefault(u => u.Id == oldTeacher.Id);
            return newTeacher;
        }
    }
}