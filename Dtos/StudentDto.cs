using System.ComponentModel.DataAnnotations;

namespace prueba.Dtos
{
    public class StudentDto
    {
        public int? Id { get; set; }
        public string? Names { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}