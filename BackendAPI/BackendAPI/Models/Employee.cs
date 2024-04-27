using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        public string? Phone { get; set; }

        [Range(10, 100, ErrorMessage = "Age must be greater then 10 and less then 100")]
        public int? Age { get; set; }
        
        public int? Salary { get; set; }
    }
}
