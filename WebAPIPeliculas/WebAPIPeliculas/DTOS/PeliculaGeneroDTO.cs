namespace WebAPIPeliculas.DTOS
{
    public class PeliculaGeneroDTO
    {
        public int IdPelicula { get; set; }
        public int IdGenero { get; set; }

        public virtual GeneroDTO Genero { get; set; }
    }
}
