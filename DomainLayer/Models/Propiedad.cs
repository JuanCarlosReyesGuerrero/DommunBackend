﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum NumPisos
    {
        [Description("1")]
        Uno = 1,

        [Description("2")]
        Dos = 2,

        [Description("3")]
        Tres = 3,

        [Description("4")]
        Cuatro = 4,

        [Description("5+")]
        Cinco = 5,
    }

    public class Propiedad : BaseEntity
    {
        public string? Titulo { get; set; }
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

        //public int NumeroPiso { get; set; }
        [EnumDataType(typeof(NumPisos)), Display(Name = "Número de Pisos")]
        public NumPisos NumPiso { get; set; }
        
        public decimal AreaFondo{ get; set; }
        public int? TiempoConstruidoId { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int NumeroBanos { get; set; }
        public int NumeroParqueaderos { get; set; }
        public int? TipoParqueaderoId { get; set; }
        public int? CaracteristicaParqueaderoId { get; set; }


        public string? Caracteristicas { get; set; }


        public string? Video { get; set; }
        public string? Descripcion { get; set; }
        public int AnioConstruccion { get; set; }
        public int? EstadoPropiedadId { get; set; }

        
        public int? AgenteId { get; set; }

        public virtual TipoOferta? TipoOferta { get; set; }
        public virtual TipoPropiedad? TipoPropiedad { get; set; }
        public virtual EstadoPropiedad? EstadoPropiedad { get; set; }
        public virtual Ciudad? Ciudad { get; set; }
        public virtual Agente? Agente { get; set; }
        public virtual Estrato? Estrato { get; set; }        
        public virtual TiempoConstruido? TiempoConstruido { get; set; }
        public virtual TipoParqueadero? TipoParqueadero { get; set; }
        public virtual CaracteristicaParqueadero? CaracteristicaParqueadero { get; set; }

        public virtual ICollection<FotografiaPropiedad>? FotografiaPropiedades { get; set; }
        public virtual ICollection<CaracteristicaPropiedad>? CaracteristicaPropiedades { get; set; }
    }
}