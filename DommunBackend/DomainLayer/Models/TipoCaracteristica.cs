namespace DommunBackend.DomainLayer.Models
{
    public class TipoCaracteristica : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Caracteristica>? Caracteristicas { get; set; }
    }
}
