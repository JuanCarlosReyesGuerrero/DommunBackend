namespace DomainLayer.Models
{
    public class Propiedad : BaseEntity
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Localizacion { get; set; }
        public string? Barrio { get; set; }
        public int Dormitorios { get; set; }
        public int Banos { get; set; }
        public int Garages { get; set; }
        public int Area { get; set; }
        public int AnioConstruccion { get; set; }
        public string? Caracteristicas { get; set; }
        public string? Video { get; set; }
        public string? Plano { get; set; }
        public int TipoPropiedadId { get; set; }
        public int EstadoPropiedadId { get; set; }        
        public int CiudadId { get; set; }
        public int AgenteId { get; set; }

        public virtual TipoPropiedad? TipoPropiedad { get; set; }
        public virtual EstadoPropiedad? EstadoPropiedad { get; set; }        
        public virtual Ciudad? Ciudad { get; set; }
        public virtual Agente? Agente { get; set; }

        public virtual ICollection<FotografiaPropiedad>? FotografiaPropiedades { get; set; }
    }
}
