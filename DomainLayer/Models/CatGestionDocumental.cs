namespace DomainLayer.Models
{
    public class CatGestionDocumental : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<GestionDocumental>? GestionDocumentales { get; set; }
    }
}
