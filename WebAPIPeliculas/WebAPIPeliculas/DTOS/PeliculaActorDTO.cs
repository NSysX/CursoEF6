namespace WebAPIPeliculas.DTOS
{
    public class PeliculaActorDTO
    {
        public int IdPelicula { get; set; }
        public int IdActor { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }

        public virtual ActorDTO Actor { get; set; }
    }
}
