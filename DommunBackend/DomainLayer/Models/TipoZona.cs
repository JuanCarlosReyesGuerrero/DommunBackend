namespace DommunBackend.DomainLayer.Models
{
    public class TipoZona : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Zona>? Zonas { get; set; }
        public virtual ICollection<ZonaDommun>? ZonaDommuns { get; set; }
    }
}
