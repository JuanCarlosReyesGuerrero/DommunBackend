namespace DomainLayer.Models
{
    public class Zonificacion : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public ICollection<Agente>? Agentes { get; set; }
    }
}
