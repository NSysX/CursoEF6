using WebAPIPeliculas.Entities;
using WebAPIPeliculas.Enum;

namespace WebAPIPeliculas.DTOS
{
    public class SalaCineDTO
    {
        public int Id { get; set; }
        public TipoSalaCine TipoSalaCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }

        public virtual CineDTO Cine { get; set; }
    }
}
