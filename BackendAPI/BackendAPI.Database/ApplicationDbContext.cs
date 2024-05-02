using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
