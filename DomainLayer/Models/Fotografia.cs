namespace DomainLayer.Models
{
    public class Fotografia : BaseEntity
    {
        public string? Imagen { get; set; }
        public bool Valida { get; set; }
        public bool EsPrincipal { get; set; }        
        public int? PropiedadId { get; set; }

        public Propiedad? propiedad { get; set; }
    }
}
