using WebAPIPeliculas.Enum;

namespace WebAPIPeliculas.Entities
{
    public class SalaCine
    {
        public int Id { get; set; }
        public TipoSalaCine TipoSalaCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }

        public virtual Cine Cine { get; set; }
        public virtual ICollection<PeliculaSalaCine> PeliculaSalaCines { get; set; }
    }
}
