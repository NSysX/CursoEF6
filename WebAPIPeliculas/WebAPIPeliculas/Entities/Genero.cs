namespace WebAPIPeliculas.Entities
{
    public class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<PeliculaGenero>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual HashSet<PeliculaGenero> Peliculas { get; set; }
    }
}
