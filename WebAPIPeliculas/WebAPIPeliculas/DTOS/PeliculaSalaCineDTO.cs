using WebAPIPeliculas.Entities;

namespace WebAPIPeliculas.DTOS
{
    public class PeliculaSalaCineDTO
    {
        public int IdPelicula { get; set; }
        public int IdSalaCine { get; set; }

        public virtual SalaCineDTO SalaCine { get; set; }
    }
}
