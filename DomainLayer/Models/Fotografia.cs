namespace DomainLayer.Models
{
    public class Fotografia : BaseEntity
    {
        public string? Imagen { get; set; }
        public bool Valida { get; set; }
        public bool EsPrincipal { get; set; }

        public virtual ICollection<FotografiaPropiedad>? FotografiaPropiedades { get; set; }
    }
}
