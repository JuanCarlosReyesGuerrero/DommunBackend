using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposNegocioComercial
    {
        [Description("Arriendo")]
        Arriendo = 1,

        [Description("Venta")]
        Venta = 2,
    }

    public class PublicacionComercial : BaseEntity
    {
        [EnumDataType(typeof(TiposNegocioComercial)), Display(Name = "Tipo Negocio Comercial")]
        public TiposNegocioComercial TipoNegocioComercial { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
