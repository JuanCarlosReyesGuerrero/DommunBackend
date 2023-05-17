namespace DomainLayer.Models
{
    public class Agente : BaseEntity
    {
        public string? Slug { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? FotoPerfil { get; set; }
        public string? DescripcionPerfil { get; set; }
        public string? Celular { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? Instagram { get; set; }
        public string? Website { get; set; }
        public int? InmobiliariaId { get; set; }       
        

        public virtual Inmobiliaria? Inmobiliaria { get; set; }

        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
