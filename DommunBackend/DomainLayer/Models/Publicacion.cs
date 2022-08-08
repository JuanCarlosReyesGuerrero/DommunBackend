using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.Models
{
    public enum TiposUrgencia
    {
        [Description("PPP")]
        PPP = 1,

        [Description("PP")]
        PP = 2,

        [Description("P")]
        P = 3,
    }

    public enum TiposPublicacion
    {
        [Description("En Validación Fotos")]
        EstadoCreado = 1,

        [Description("En proceso SAB")]
        EstadoValidacion = 2,

        [Description("Publicación NO CUMPLE")]
        EstadoPublicacionNoCumple = 3,

        [Description("Publicado")]
        EstadoPublicado = 4,

        [Description("Cerrado por Dommun")]
        EstadoCerradoConDommun = 5,

        [Description("El cliente se arrepintió")]
        EstadoClienteSeArrepintio = 6,

        [Description("El cliente cerró por otro medio")]
        EstadoClienteVendioOtroMedio = 7,

        [Description("El broker decide no continuar")]
        EstadoBrokerDecideNoContinuar = 8,

        [Description("Cliente no aparece")]
        EstadoClienteNoAparece = 9,

        [Description("Cliente pide cambio de broker")]
        EstadoClientePideCambioBroker = 10,

        [Description("Duplicado")]
        EstadoDuplicado = 11,

        [Description("Despublicado")]
        EstadoDespublicado = 12,
    }

    public class Publicacion : BaseEntity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Razon { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioAdmon { get; set; }
        public bool EsExclusivo { get; set; }
        public string? CertificadoLibTrad { get; set; }
        public string? Contrato { get; set; }
        public bool PublicadoPortales { get; set; }
        public bool ConfirmoMotivo { get; set; }
        public bool BajoPrecio { get; set; }
        public int Visitas { get; set; }
        public int AgenteId { get; set; }


        [EnumDataType(typeof(TiposUrgencia)), Display(Name = "Tipo Urgencia")]
        public TiposUrgencia TipoUrgencia { get; set; }

        [EnumDataType(typeof(TiposPublicacion)), Display(Name = "Tipo Publicación")]
        public TiposPublicacion TipoPublicacion { get; set; }      

        public virtual Agente? Agente { get; set; }

        public PublicacionComercial? PublicacionComercial { get; set; }
        public PublicacionIndustrial? PublicacionIndustrial { get; set; }
        public PublicacionLote? PublicacionLote { get; set; }
        public PublicacionVivienda? PublicacionVivienda { get; set; }
    }
}
