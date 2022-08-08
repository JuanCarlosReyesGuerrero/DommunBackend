using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.Models
{
    public enum TiposComercial
    {
        [Description("Local")]
        Local = 1,

        [Description("Oficinas")]
        Oficinas = 2,
    }

    public enum TiposEstacionamientosIndustrial
    {
        [Description("No tiene")]
        TipoNoTiene = 1,

        [Description("En fila")]
        TipoEnFila = 2,

        [Description("Independientes")]
        TipoIndependiente = 3,
    }

    public class Comercial : BaseEntity
    {
        public int Espacios { get; set; }
        public bool Cocineta { get; set; }
        public int Banos { get; set; }
        public int AnioConstruccion { get; set; }
        public int Balcones { get; set; }
        public int Terrazas { get; set; }
        public decimal AreaPrivada { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaTerraza { get; set; }
        public int EstacionamientosCubiertos { get; set; }
        public int EstacionamientosDescubiertos { get; set; }
        public int EstacionamientosTotales { get; set; }
        public bool Amoblado { get; set; }
        public int Estrato { get; set; }
        public bool Deposito { get; set; }


        [EnumDataType(typeof(TiposComercial)), Display(Name = "Tipo Comercial")]
        public TiposComercial TipoComercial { get; set; }

        [EnumDataType(typeof(TiposEstacionamientosIndustrial)), Display(Name = "Tipo Estacionamientos")]
        public TiposEstacionamientosIndustrial TipoEstacionamientos { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
