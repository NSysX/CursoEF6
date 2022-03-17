using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebAPIPeliculas.Contexts;
using WebAPIPeliculas.DTOS;

namespace WebAPIPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly PeliculasDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorController(PeliculasDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> GetActores()
        {
            // usando el select con objeto anonimo
            // var actores = await this._dbContext.Actor.Select(c => new { c.Id, c.Nombre }).ToListAsync();

            // usando el select sin objecto anonimo
            // return await this._dbContext.Actor.Select(r => new ActorDTO { Id = r.Id, Nombre = r.Nombre }).ToListAsync();

            //---- Usando AutoMapper original
            //var actores = await this._dbContext.Actor.ToListAsync();
            //var dtos = this._mapper.Map<IEnumerable<ActorDTO>>(actores);
            //return dtos;

            //--- Usando El ProjectTo
            return await this._dbContext.Actor
                  .ProjectTo<ActorDTO>(this._mapper.ConfigurationProvider)
                  .ToListAsync();
        }

        [HttpGet("Cercanos")]
        public async Task<ActionResult> GetSercanos(double latitud, double longitud)
        {
            // mediciones sobre nustro planeta tierra
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            
            // creo mi ubicacion
            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));

            // hacemos la consulta
            var cines = await this._dbContext.Cine
                                             .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                                             .Select(c => new
                                             {
                                                 Nombre = c.Nombre,
                                                 Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion))
                                             }).ToListAsync();

            return Ok(cines); 
        }
    }
}
