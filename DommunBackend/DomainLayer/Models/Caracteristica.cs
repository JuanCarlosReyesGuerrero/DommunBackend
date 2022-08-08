namespace DommunBackend.DomainLayer.Models
{
    public class Caracteristica : BaseEntity
    {
        public string? Nombre { get; set; }
        public bool AplicaApartamento { get; set; }
        public bool AplicaCasa { get; set; }
        public bool AplicaOficina { get; set; }
        public bool AplicaBodega { get; set; }
        public bool AplicaLocal { get; set; }
        public bool AplicaLote { get; set; }
        public int TipoCaracteristicaId { get; set; }

        public virtual TipoCaracteristica? TipoCaracteristica { get; set; }
        
        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
