using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.Models
{
    public enum TiposNegocioVivienda
    {
        [Description("Arriendo")]
        Arriendo = 1,

        [Description("Venta")]
        Venta = 2,
    }

    public class PublicacionVivienda : BaseEntity
    {
        [EnumDataType(typeof(TiposNegocioVivienda)), Display(Name = "Tipo Negocio Vivienda")]
        public TiposNegocioVivienda TipoNegocioVivienda { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
