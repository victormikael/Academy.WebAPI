using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public string Certified { get; set; }
    }
}