namespace WebAPIPeliculas.Entities
{
    public class Pelicula
    {
        public Pelicula()
        {
            Generos = new HashSet<PeliculaGenero>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string PosterURL { get; set; }

        public virtual HashSet<PeliculaGenero> Generos { get; set; }
        public virtual ICollection<PeliculaSalaCine> PeliculaSalaCines { get; set; }
        public virtual ICollection<PeliculaActor> Actores { get; set; }
    }
}
