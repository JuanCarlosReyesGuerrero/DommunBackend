namespace DommunBackend.DomainLayer.Models
{
    public class DocumentoPropiedad : BaseEntity
    {
        public string? Archivo { get; set; }
        public int PropiedadId { get; set; }
        public int TipoDocumentoPropiedadId { get; set; }

        public virtual TipoDocumentoPropiedad? TipoDocumentoPropiedad { get; set; }

           // public vir
    }
}
