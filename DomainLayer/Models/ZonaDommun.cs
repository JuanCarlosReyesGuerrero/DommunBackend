namespace DomainLayer.Models
{
    public class ZonaDommun : BaseEntity
    {
        public int AgenteId { get; set; }
        public int TipoZonaId { get; set; }

        public virtual Agente? Agente { get; set; }
        public virtual TipoZona? TipoZona { get; set; }
    }
}
