namespace DomainLayer.Models
{
    public class CaracteristicaPropiedad : BaseEntity
    {
        public int PropiedadId { get; set; }
        public int CaracteristicaId { get; set; }

        public virtual Propiedad? Propiedad { get; set; }
        public virtual Caracteristica? Caracteristica { get; set; }
    }
}
