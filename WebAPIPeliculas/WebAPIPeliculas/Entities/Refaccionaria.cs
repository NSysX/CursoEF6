using NetTopologySuite.Geometries;

namespace WebAPIPeliculas.Entities
{
    public class Refaccionaria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
    }
}
