using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DomainLayer.Dtos
{
    public class PropiedadFullDto
    {
        [HiddenInput]
        public int Id { get; set; }
        public int? TipoOfertaId { get; set; }
        public int? TipoPropiedadId { get; set; }
        public double ValorVenta { get; set; }
        public double ValorArriendo { get; set; }
        public bool IncluyeAdministracion { get; set; }
        public double ValorAdministracion { get; set; }
        public double ValorMetro { get; set; }

        public int? CiudadId { get; set; }
        public string? Direccion { get; set; }
        public string? Barrio { get; set; }
        public string? Localizacion { get; set; }

        public int? EstratoId { get; set; }
        public decimal AreaPrivada { get; set; }
        public decimal AreaConstruida { get; set; }

        public int? NumeroPiso { get; set; }
        public decimal AreaFondo { get; set; }
        public int? TiempoConstruidoId { get; set; }
        public int? NumeroHabitacionId { get; set; }
        public int? NumeroBanoId { get; set; }
        public int? NumeroParqueaderoId { get; set; }
        public int? TipoParqueaderoId { get; set; }
        public int? CaracteristicaParqueaderoId { get; set; }


        public string? Caracteristicas { get; set; }


        public string? Video { get; set; }
        public string? Descripcion { get; set; }
        public int AnioConstruccion { get; set; }
        public int? EstadoPropiedadId { get; set; }


        public int? AgenteId { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }


        //public TipoOfertaDto? TipoOferta { get; set; }
        //public TipoPropiedadDto? TipoPropiedad { get; set; }
        //public EstadoPropiedadDto? EstadoPropiedad { get; set; }
        //public CiudadDto? Ciudad { get; set; }
        //public AgenteDto? Agente { get; set; }
        //public EstratoDto? Estrato { get; set; }

        //public TiempoConstruidoDto? TiempoConstruido { get; set; }
        //public TipoParqueaderoDto? TipoParqueadero { get; set; }
        //public CaracteristicaParqueaderoDto? CaracteristicaParqueadero { get; set; }
        //public NumeroBanoDto? NumeroBano { get; set; }
        //public NumeroHabitacionDto? NumeroHabitacion { get; set; }
        //public NumeroParqueaderoDto? NumeroParqueadero { get; set; }
    }
}
