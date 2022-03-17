using WebAPIPeliculas.Entities;

namespace WebAPIPeliculas.DTOS
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string PosterURL { get; set; }

        public virtual ICollection<GeneroDTO> Genero { get; set; }
        public virtual ICollection<CineDTO> Cine { get; set; }
        public virtual ICollection<ActorDTO> Actor { get; set; }
    }
}
