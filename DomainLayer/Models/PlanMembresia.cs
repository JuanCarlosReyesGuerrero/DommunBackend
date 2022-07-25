namespace DomainLayer.Models
{
    public class PlanMembresia : BaseEntity
    {
        public string? Nombre { get; set; }
        public decimal PrecioPromocion { get; set; }
        public decimal PrecioFijo { get; set; }

        public ICollection<Agente>? Agentes { get; set; }
    }
}
