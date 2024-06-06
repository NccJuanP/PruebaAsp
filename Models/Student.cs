using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace prueba.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Enrollment>? Enrrollment { get; set; }
    }
}