namespace DomainLayer.Models
{
    public class Caracteristica : BaseEntity
    {
        //public Caracteristica() 
        //{
        //    this.TipoPropiedadByCaracteristica = new HashSet<TipoPropiedadByCaracteristica>();
        //}

        public string? Codigo { get; set; }
        public int TipoCaracteristicaId { get; set; }
        public string? Nombre { get; set; }

        public virtual TipoCaracteristica? TipoCaracteristica { get; set; }

        public virtual ICollection<CaracteristicaPropiedad>? CaracteristicaPropiedades { get; set; }
        public virtual ICollection<TipoPropiedadByCaracteristica>? TipoPropiedadByCaracteristicas { get; set; }
    }
}
