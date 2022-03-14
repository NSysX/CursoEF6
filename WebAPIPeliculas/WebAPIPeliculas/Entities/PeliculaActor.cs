namespace WebAPIPeliculas.Entities
{
    public class PeliculaActor
    {
        public int id { get; set; }
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
