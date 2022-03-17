using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebAPIPeliculas.Contexts;

namespace WebAPIPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefaccionariaController : ControllerBase
    {
        private readonly PeliculasDbContext _peliculasDb;

        public RefaccionariaController(PeliculasDbContext peliculasDb)
        {
            this._peliculasDb = peliculasDb;
        }

        [HttpGet("Cercanos")]
        public async Task<ActionResult> getCercanos(double latitud, double longitud)
        {
            GeometryFactory geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Point miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud,latitud));
            int distaciaMaximaEnMt = 2000;

            var entities = await this._peliculasDb.Refaccionaria
                                     .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                                     .Where(c => c.Ubicacion.IsWithinDistance(miUbicacion,distaciaMaximaEnMt))
                                     .Select(n => new
                                     {
                                         Nombre = n.Nombre,
                                         Distancia = Math.Round(n.Ubicacion.Distance(miUbicacion))
                                     }).ToListAsync();

            return Ok(entities);
        }

    }
}
