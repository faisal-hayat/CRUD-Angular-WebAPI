using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        // This is where we will be adding the models to DB
    }
}
