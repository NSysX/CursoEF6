using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPIPeliculas.Entities;
using WebAPIPeliculas.Entities.Seeds;

namespace WebAPIPeliculas.Contexts
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions options) : base(options)
        {
           // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cine> Cine { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<CineOferta> CineOferta { get; set; }
        public DbSet<SalaCine> SalaCine { get; set; }
        public DbSet<PeliculaActor> PeliculaActor { get; set; }
        public DbSet<PeliculaGenero> PeliculaGenero { get; set; }
        public DbSet<PeliculaSalaCine> PeliculaSalaCine { get; set; }
        public DbSet<Refaccionaria> Refaccionaria { get; set; }

        // aqui se configura el API FLuent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // para que aplique las configuraciones que esten en otras clases para no tenerlas todas aqui
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           // SeedOriginal.Seed(modelBuilder);

            // para insertar el seeding
             SeedModuloConsulta.Seed(modelBuilder);
           // Seed2.InsertaSeed2(modelBuilder);
        }
    }
}
