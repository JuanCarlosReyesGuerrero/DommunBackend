namespace DomainLayer.Models
{
    public class TipoPropiedadByCaracteristica : BaseEntity
    {
        public int IdCaracteristica { get; set; }
        public int IdTipoPropiedad { get; set; }

        public virtual Caracteristica Caracteristicas { get; set; }
        public virtual TipoPropiedad TipoPropiedades { get; set; }
    }
}
