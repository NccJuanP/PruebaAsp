using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace prueba.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TeacherId { get; set; }
        public string? Schedule { get; set; }
        public string? Duration { get; set; }
        public int? Capacity { get; set; }

        public Teacher? Teacher { get; set; }
        [JsonIgnore]
        public List<Enrollment>? Enrrollment { get; set; }
    }
}