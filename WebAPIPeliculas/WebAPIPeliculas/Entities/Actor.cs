namespace WebAPIPeliculas.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual HashSet<PeliculaActor> Peliculas { get; set; }
    }
}
