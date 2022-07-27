namespace DomainLayer.Models
{
    public class Municipio : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Departamento? Departamento { get; set; }

        public ICollection<Agente>? Agentes { get; set; }
        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
