using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposBodega
    {
        [Description("Bodega")]
        Bodega = 1,
    }

    public class Industrial : BaseEntity
    {
        public int Espacios { get; set; }
        public int Banos { get; set; }
        public int AnioConstruccion { get; set; }
        public decimal AreaPrivada { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaLote { get; set; }


        [EnumDataType(typeof(TiposBodega)), Display(Name = "Tipo Bodega")]
        public TiposBodega TipoBodega { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
