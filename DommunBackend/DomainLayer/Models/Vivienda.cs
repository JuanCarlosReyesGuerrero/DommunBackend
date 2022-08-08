using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.Models
{
    public enum TiposVivienda
    {
        [Description("Apartamento")]
        Apartamento = 1,

        [Description("Casa")]
        Casa = 2,
    }

    public enum TiposEstacionamientosVivienda
    {
        [Description("No tiene")]
        TipoNoTiene = 1,

        [Description("En fila")]
        TipoEnFila = 2,

        [Description("Independientes")]
        TipoIndependiente = 3,
    }

    public class Vivienda : BaseEntity
    {
        public int Habitaciones { get; set; }
        public int Estudios { get; set; }
        public int HabitacionesAuxiliares { get; set; }
        public int Banos { get; set; }
        public int BanosSociales { get; set; }
        public int BanosServicio { get; set; }
        public int AnioConstruccion { get; set; }
        public int Balcones { get; set; }
        public int Terrazas { get; set; }
        public decimal AreaPrivada { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaTerraza { get; set; }
        public decimal AreaLote { get; set; }
        public int EstacionamientosCubiertos { get; set; }
        public int EstacionamientosDescubiertos { get; set; }
        public int EstacionamientosTotales { get; set; }
        public bool Amoblado { get; set; }
        public int Estrato { get; set; }
        public bool Deposito { get; set; }


        [EnumDataType(typeof(TiposVivienda)), Display(Name = "Tipo Vivienda")]
        public TiposVivienda TipoVivienda { get; set; }

        [EnumDataType(typeof(TiposEstacionamientosVivienda)), Display(Name = "Tipo Estacionamientos")]
        public TiposEstacionamientosVivienda TipoEstacionamientos { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
