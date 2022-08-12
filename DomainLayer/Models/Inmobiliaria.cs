namespace DomainLayer.Models
{
    public class Inmobiliaria : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nit { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Agente>? Agentes { get; set; }
    }
}
