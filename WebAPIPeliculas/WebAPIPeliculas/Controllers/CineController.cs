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
    public class CineController : ControllerBase
    {
        private readonly PeliculasDbContext _dbContext;
        private readonly IMapper _mapper;

        public CineController(PeliculasDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTO>> GetCine()
        {
            return await this._dbContext.Cine
                                  .ProjectTo<CineDTO>(this._mapper.ConfigurationProvider)
                                  .ToListAsync();
        }

        //[HttpGet("Cercanos")]
        //public async Task<ActionResult> getCercanos(double latitud, double longitud)
        //{
        //    var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        //    var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));
        //}
    }
}
