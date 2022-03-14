using Microsoft.EntityFrameworkCore;
using WebAPIEF6.Entities;

namespace WebAPIEF6
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
    }
}
