using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFCore6
{
    public class ApplicationConsoleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\DEV;DataBase=CursoEF6;UID=sa;PWD=123456");
        }

        public DbSet<Persona1> Persona { get; set; }
    }
}
