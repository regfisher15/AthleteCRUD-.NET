using Microsoft.EntityFrameworkCore;
using Athletes.Models;

namespace Athletes.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 

        }

        public DbSet<Athlete> Athletes { get; set; }
    }
}
