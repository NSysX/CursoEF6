namespace WebAPIPeliculas.Entities
{
    public class PeliculaSalaCine
    {
        public int IdPelicula { get; set; }
        public int IdSalaCine { get; set; }
        
        public virtual Pelicula Pelicula { get; set; }
        public virtual SalaCine SalaCine { get; set; } 
    }
}
