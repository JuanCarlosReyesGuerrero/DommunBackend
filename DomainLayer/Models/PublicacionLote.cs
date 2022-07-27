using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposNegocioLote
    {
        [Description("Arriendo")]
        Arriendo = 1,

        [Description("Venta")]
        Venta = 2,
    }

    public class PublicacionLote : BaseEntity
    {

        [EnumDataType(typeof(TiposNegocioLote)), Display(Name = "Tipo Negocio Lote")]
        public TiposNegocioLote TipoNegocioLote { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
