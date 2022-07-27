namespace DomainLayer.Models
{
    public class Cliente : BaseEntity
    {
        //    user = models.ForeignKey(
        //    User,
        //    null=True,
        //    blank=True,
        //    unique=True,
        //    related_name='cliente',
        //)

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Email { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? TelefonoSecundario { get; set; }
        public int AgenteId { get; set; }

        public virtual Agente? Agente { get; set; }
    }
}
