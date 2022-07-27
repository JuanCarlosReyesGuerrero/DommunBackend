using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposNegocioIndustrial
    {
        [Description("Arriendo")]
        Arriendo = 1,

        [Description("Venta")]
        Venta = 2,
    }

    public class PublicacionIndustrial : BaseEntity
    {
        [EnumDataType(typeof(TiposNegocioIndustrial)), Display(Name = "Tipo Negocio Industrial")]
        public TiposNegocioIndustrial TipoNegocioIndustrial { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
