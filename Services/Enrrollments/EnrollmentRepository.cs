using System.Reflection;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;

namespace prueba.Services.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly pruebaContext _context;
        public EnrollmentRepository(pruebaContext context)
        {
            _context = context;
        }

        //Cuerpo de la funcion para crear una matricula
        public Enrollment CreateEnrrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            Enrollment enrrollment1 = _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).FirstOrDefault(u => u.Id == enrollment.Id);
            return enrrollment1;
        }

        //Cuerpo de la funcion para listar las matriculas
        public List<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).ToList();
        }

        //Cuerpo de la funcion para listar las matriculas por fecha especifica
        public List<Enrollment> GetEnrollmentsByDate(DateOnly date)
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).Where(u => u.Date == date).ToList();
        }

        //Cuerpo de la funcion para listar una matricula por id
        public Enrollment? GetEnrrollmentById(int id)
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).FirstOrDefault(u => u.Id == id);
        }

        //Cuerpo de la funcion para actualizar una matricula   
        public Enrollment UpdateEnrrollment(Enrollment enrollment, int id)
        {
            if (enrollment.Id != id)
            {
                return null;
            }

            if (_context.Enrollments.Find(id) == null)
            {
                return null;
            }

            switch (enrollment.Status)
            {
                case "PAGADA":
                    break;
                case "PENDIENTE DE PAGO":
                    break;
                case "CANCELADA":
                    break;
                default:
                    return null;
            }

            Enrollment oldEnrollments = _context.Enrollments.Find(id);

            //recorremos el objeto verificando que propiedades son nulas y cuales no
            foreach (PropertyInfo property in enrollment.GetType().GetProperties())
            {
                if (property.GetValue(enrollment) != null)
                {
                    property.SetValue(oldEnrollments, property.GetValue(enrollment));
                }
            }

            _context.Enrollments.Update(oldEnrollments);
            _context.SaveChanges();
            Enrollment newEnrollment = _context.Enrollments.Include(u => u.Student).Include(c => c.Course).ThenInclude(t => t.Teacher).FirstOrDefault(u => u.Id == oldEnrollments.Id);
            return newEnrollment;
        }
    }
}