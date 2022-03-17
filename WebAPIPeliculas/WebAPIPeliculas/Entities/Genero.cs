namespace WebAPIPeliculas.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual HashSet<PeliculaGenero> PeliculaGenero { get; set; }
    }
}
