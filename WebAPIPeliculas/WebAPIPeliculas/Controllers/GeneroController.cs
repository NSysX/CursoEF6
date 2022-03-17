using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPeliculas.Contexts;
using WebAPIPeliculas.Entities;

namespace WebAPIPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly PeliculasDbContext _dbContext;

        public GeneroController(PeliculasDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> GetAllGeneros()
        {
            return await this._dbContext.Genero.OrderBy(n => n.Nombre).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> GetAction(int id)
        {
            var genero = await this._dbContext.Genero.FirstOrDefaultAsync(x => x.Id == id);
            if (genero is null) return NotFound();
            return genero;
        }

        [HttpGet("Primero")]
        public async Task<ActionResult<Genero>> GetPrimero()
        {
            //return await _dbContext.Genero.FirstAsync(c => c.Nombre.StartsWith("C"));
            var genero = await this._dbContext.Genero.FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));
            if (genero is null) return NotFound();
            return genero;
        }

        [HttpGet("Filtrar")]
        public async Task<ActionResult<IEnumerable<Genero>>> GeneroXParametors(string filtro)
        {
            //var entities = await this._dbContext.Genero.Where(
            //                c => c.Nombre.StartsWith("C") || c.Nombre.StartsWith("A")
            //                                                 ).ToListAsync();

            var entities = await this._dbContext.Genero
                                     .Where(n => n.Nombre.Contains(filtro))
                                     .OrderBy(g => g.Nombre)
                                     .ToListAsync();
            return entities;
        }

        [HttpGet("Paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int numeroPagina = 1)
        {
            //var generosPaginados = await this._dbContext.Genero
            //                                 .Skip(1)
            //                                 .Take(RegistrosXPagina)
            //                                 .ToListAsync();
            var RegistrosXPagina = 2;
            var datoskip2 = (numeroPagina - 1) * RegistrosXPagina;

            var generosPaginados = await this._dbContext.Genero
                                             .Skip(datoskip2)
                                             .Take(RegistrosXPagina)
                                             .ToListAsync();

            return generosPaginados;
        }
    }
}
