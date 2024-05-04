using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Models.OOP
{
    // this class cant be inherited
    public sealed class BookSealed
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        public required string Title { get; set; }

    }

    public static class BookStatic
    {
        [Key]
        public static int Id { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        public static string? Title { get; set; }
    }

    
}
