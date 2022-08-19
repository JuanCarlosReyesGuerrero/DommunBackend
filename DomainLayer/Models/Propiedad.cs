namespace DomainLayer.Models
{
    public class Propiedad : BaseEntity
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Localizacion { get; set; }
        public string? Barrio { get; set; }
        public int Habitaciones { get; set; }
        public int Banos { get; set; }
        public int Parqueaderos { get; set; }
        public int AreaConstruida { get; set; }
        public int AreaPrivada { get; set; }
        public int? EstratoId { get; set; }
        public int? TipoNegocioId { get; set; }
        public int Antiguedad { get; set; }
        public int Piso { get; set; }
        public double Administracion { get; set; }
        public double PrecioMetro { get; set; }
        public int AnioConstruccion { get; set; }
        public string? Caracteristicas { get; set; }
        public string? Video { get; set; }
        public string? Plano { get; set; }
        public int? TipoPropiedadId { get; set; }
        public int? EstadoPropiedadId { get; set; }
        public int? CiudadId { get; set; }
        public int? AgenteId { get; set; }

        public virtual TipoPropiedad? TipoPropiedad { get; set; }
        public virtual EstadoPropiedad? EstadoPropiedad { get; set; }
        public virtual Ciudad? Ciudad { get; set; }
        public virtual Agente? Agente { get; set; }
        public virtual Estrato? Estrato { get; set; }
        public virtual TipoNegocio? TipoNegocio { get; set; }

        public virtual ICollection<FotografiaPropiedad>? FotografiaPropiedades { get; set; }
        public virtual ICollection<CaracteristicaPropiedad>? CaracteristicaPropiedades { get; set; }
    }
}
