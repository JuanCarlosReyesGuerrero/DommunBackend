namespace DomainLayer.Models
{
    public class Agente : BaseEntity
    {
        //    user = models.ForeignKey(
        //   User,
        //    null=True,
        //    blank=True,
        //    unique=True,
        //    related_name='agente',
        //)


        public string? Slug { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? Descripcion { get; set; }
        public string? FotoPerfil { get; set; }
        public bool AeptaArriendo { get; set; }
        public bool AceptaVenta { get; set; }
        public bool Publicado { get; set; }
        public double PrecioArriendoMin { get; set; }
        public double PrecioVentaMin { get; set; }
        public string? DescripcionPerfil { get; set; }
        public int NumeroAvaluo { get; set; }
        public DateTime fecha_inicio_plan { get; set; }
        public string? RedesSociales { get; set; }
        public int ZonificacionId { get; set; }
        public int PlanMembresiaId { get; set; }
        public int MunicipioId { get; set; }

        public virtual Zonificacion? Zonificacion { get; set; }
        public virtual PlanMembresia? PlanMembresia { get; set; }
        public virtual Municipio? Municipio { get; set; }

        public virtual ICollection<ZonaDommun>? ZonaDommuns { get; set; }
        public virtual ICollection<Cliente>? Clientes { get; set; }
        public virtual ICollection<Propiedad>? Propiedades { get; set; }
        public virtual ICollection<Publicacion>? Publicaciones { get; set; }
    }
}
