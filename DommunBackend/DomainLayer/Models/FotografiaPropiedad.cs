namespace DommunBackend.DomainLayer.Models
{
    public class FotografiaPropiedad : BaseEntity
    {
        public string? Image { get; set; }
        public bool Valida { get; set; }
        public bool EsPrincipal { get; set; }
        public int Orden { get; set; }
        public int PropiedadId { get; set; }

        public virtual Propiedad? Propiedad { get; set; }
    }
}
