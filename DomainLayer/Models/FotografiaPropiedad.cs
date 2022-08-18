namespace DomainLayer.Models
{
    public class FotografiaPropiedad : BaseEntity
    {
        public int FotografiaId { get; set; }
        public bool PropiedadId { get; set; }

        public virtual Fotografia? Fotografia { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
