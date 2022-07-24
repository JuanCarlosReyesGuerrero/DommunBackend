namespace DomainLayer.Models
{
    public class Departamento : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public ICollection<Municipio>? Municipios { get; set; }
    }
}
