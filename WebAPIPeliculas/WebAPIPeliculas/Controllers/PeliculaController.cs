using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPeliculas.Contexts;
using WebAPIPeliculas.DTOS;
using WebAPIPeliculas.Entities;

namespace WebAPIPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly PeliculasDbContext _dbContext;
        private readonly IMapper _mapper;

        public PeliculaController(PeliculasDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetById(int id)
        {
            var entity = await this._dbContext.Pelicula
                                   .Include(p => p.PeliculaGenero)
                                   .Include(p => p.PeliculaSalaCine)
                                     .ThenInclude(p => p.SalaCine)
                                         .ThenInclude(p => p.Cine)
                                   .Include(p => p.PeliculaActores)
                                   // .ProjectTo<PeliculaDTO>(this._mapper.ConfigurationProvider)
                                   .FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null) return NotFound();

            PeliculaDTO peliculaDTO = this._mapper.Map<PeliculaDTO>(entity);

            peliculaDTO.Cine = peliculaDTO.Cine.DistinctBy(x => x.Id).ToList();

            return Ok(peliculaDTO);
        }
    }
}
