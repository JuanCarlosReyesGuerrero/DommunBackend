namespace DomainLayer.Models
{
    public class GestionDocumental : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? DocumentoSubido { get; set; }
        public int CategoriaId { get; set; }

        public virtual CatGestionDocumental? CatGestionDocumental { get; set; }
    }
}
