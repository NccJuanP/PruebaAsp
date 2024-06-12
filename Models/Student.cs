using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace prueba.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public DateOnly? BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public List<Enrollment> Enrrollment { get; set; }
    }
}