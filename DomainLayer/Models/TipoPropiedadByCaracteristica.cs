namespace DomainLayer.Models
{
    public class TipoPropiedadByCaracteristica : BaseEntity
    {
        public virtual Caracteristica Caracteristicas { get; set; }
        public virtual TipoPropiedad TipoPropiedades { get; set; }

        public virtual ICollection<CaracteristicaPropiedad>? CaracteristicaPropiedades { get; set; }
    }
}
