namespace WebAPIPeliculas.Entities
{
    public class PeliculaActor
    {
        public int IdPelicula { get; set; }
        public int IdActor { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
