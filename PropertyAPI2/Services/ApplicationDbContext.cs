using Microsoft.EntityFrameworkCore;

namespace PropertyAPI2.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public required DbSet<PropertyAPI2.Models.Event> Events { get; set; }
    }
}
