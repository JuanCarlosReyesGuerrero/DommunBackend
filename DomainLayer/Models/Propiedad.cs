using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class Propiedad : BaseEntity
    {
        public string? MatriculaInmobiliaria { get; set; }
        public string? Dreccion { get; set; }
        public string? Dscripcion { get; set; }
        public string? LinkVirtual360 { get; set; }
        public string? Avaluo { get; set; }
        public string? Coordenadas { get; set; }
        public int CaracteristicaId { get; set; }
        public int? ClienteId { get; set; }
        public int MunicipioId { get; set; }
        public int AgenteId { get; set; }

        public virtual Caracteristica? Caracteristica { get; set; }                
        //public virtual Cliente? Cliente { get; set; }
        //public virtual Municipio? Municipio { get; set; }
        public virtual Agente? Agente { get; set; }

        public virtual ICollection<FotografiaPropiedad>? FotografiaPropiedades { get; set; }
    }
}
