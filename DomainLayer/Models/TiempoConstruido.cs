namespace DomainLayer.Models
{
    public class TiempoConstruido : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
