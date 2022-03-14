using Microsoft.EntityFrameworkCore;

namespace WebAPIPeliculas.Entities
{
    public class PeliculaGenero
    {
        public int Id { get; set; }
        public int IdPelicula { get; set; }
        public int IdGenero { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
