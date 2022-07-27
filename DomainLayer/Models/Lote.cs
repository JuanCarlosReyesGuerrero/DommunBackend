using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposLote
    {
        [Description("Lote Industrial")]
        LoteIndustrial = 1,

        [Description("Lote Vivienda")]
        LoteBodega = 2,
    }

    public class Lote : BaseEntity
    {
        public decimal AreaLote { get; set; }

        [EnumDataType(typeof(TiposLote)), Display(Name = "Tipo Lote")]
        public TiposLote TipoLote { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
