namespace DomainLayer.Models
{
    public class TipoDocumentoPropiedad : BaseEntity
    {
        public string? NombreDocumento { get; set; }
        public bool RequisitoPublicacion { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<DocumentoPropiedad>? DocumentoPropiedades { get; set; }
    }
}
