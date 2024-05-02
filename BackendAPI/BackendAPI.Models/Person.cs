using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public required string Emmail { get; set; }
        public string? Profassion { get; set; }
        public int? Salary { get; set; }
    }
}
