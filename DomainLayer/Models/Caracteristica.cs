namespace DomainLayer.Models
{
    public class Caracteristica : BaseEntity
    {
        public string? Codigo { get; set; }
        public int TipoCaracteristicaId { get; set; }
        public string? Nombre { get; set; }

        public virtual TipoCaracteristica? TipoCaracteristica { get; set; }       
        public virtual ICollection<TipoPropiedadByCaracteristica>? TipoPropiedadByCaracteristicas { get; set; }
    }
}
