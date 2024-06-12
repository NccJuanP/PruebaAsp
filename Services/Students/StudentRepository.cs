using System.Reflection;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;
using prueba.Dtos;
using AutoMapper;

namespace prueba.Services.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly pruebaContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(pruebaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Cuerpo de la funcion que crea un estudiante
        public Student CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        //Cuerpo de la funcion para obtener todos los studiantes
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        //Cuerpo de la funcion para listar todas las matriculas de un estudiante por id
        public List<Enrollment> GetEnrollmentsByStudentId(int id)
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).Where(u => u.StudentId == id).ToList();
        }

        //Cuerpo de la funcion para obtener un estudiante por id
        public Student? GetStudentById(int id)
        {
            return _context.Students.Where(u => u.Id == id).FirstOrDefault();
        }

        //Cuerpo de la funcion para listar a todos los estudiantes que cumplan años en una fecha especifica
        public List<Student> GetStudentsByDate(DateOnly date)
        {
            return _context.Students.Where(u => u.BirthDate == date).ToList();
        }

        //Cuerpo de la funcion para actualizar un estudiante por id y datos especificos
        public Student UpdateStudent(StudentDto student, int id)
        {
            if (student.Id != id)
            {
                return null;
            }

            if (_context.Students.Find(id) == null)
            {
                return null;
            }

            Student oldStudent = _context.Students.Find(id);

            _mapper.Map(student, oldStudent);

            /* //recorremos el objeto verificando que propiedades son nulas y cuales no
            foreach (PropertyInfo property in student.GetType().GetProperties())
            {
                if (property.GetValue(student) != null)
                {   
                    property.SetValue(oldStudent, property.GetValue(student));
                }
            } */

/*             _context.Students.Update(oldStudent); */
            _context.SaveChanges();
            return oldStudent;
        }
    }
}