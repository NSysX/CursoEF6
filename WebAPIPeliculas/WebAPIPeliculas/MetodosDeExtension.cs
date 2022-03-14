using Microsoft.EntityFrameworkCore;
using WebAPIPeliculas.Contexts;

namespace WebAPIPeliculas
{
    public static class MetodosDeExtension
    {
        public static void AgregaServiciosDePersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PeliculasDbContext>(opt =>
                opt.UseSqlServer(connectionString: configuration.GetConnectionString("peliculasDbConn"),
                m =>
                {
                    m.MigrationsAssembly(typeof(PeliculasDbContext).Assembly.FullName);
                    m.UseNetTopologySuite();
                }));

        }
    }
}
