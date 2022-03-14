using NetTopologySuite.Geometries;

namespace WebAPIPeliculas.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }


        public virtual CineOferta CineOferta { get; set; }
        public virtual HashSet<SalaCine> SalasCine { get; set; }
    }
}
