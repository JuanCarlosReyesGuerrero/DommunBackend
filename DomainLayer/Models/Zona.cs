using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class Zona : BaseEntity
    {        
        public string? Slug { get; set; }
        public string? Nombre { get; set; }
        public int TipoZonaId { get; set; }

        public virtual TipoZona? TipoZona  { get; set; }
    }
}
