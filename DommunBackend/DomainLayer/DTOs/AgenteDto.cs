using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.DTOs
{
    public class AgenteDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Slug")]
        public string? Slug { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string? Apellido { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Teléfono Contacto")]
        public string? TelefonoContacto { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Foto Perfil")]
        public string? FotoPerfil { get; set; }

        [Display(Name = "Acepta Arriendo")]
        public bool AceptaArriendo { get; set; }

        [Display(Name = "Acepta Venta")]
        public bool AceptaVenta { get; set; }

        [Display(Name = "Publicado")]
        public bool Publicado { get; set; }

        [Display(Name = "Precio Arriendo Min")]
        public double PrecioArriendoMin { get; set; }

        [Display(Name = "Precio Venta Min")]
        public double PrecioVentaMin { get; set; }

        [Display(Name = "Descripción Perfil")]
        public string? DescripcionPerfil { get; set; }
        
        [Display(Name = "Número Avaluo")]
        public int NumeroAvaluo { get; set; }

        [Display(Name = "Fecha Inicio Plan")]
        public DateTime FechaInicioPlan { get; set; }

        [Display(Name = "Redes Sociales")]
        public string? RedesSociales { get; set; }

        [Display(Name = "Zona")]
        public int ZonificacionId { get; set; }
        
        [Display(Name = "Plan Membresia")]
        public int PlanMembresiaId { get; set; }

        [Display(Name = "Municipio")]
        public int MunicipioId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Zonificación")]
        public string? ZonificacionNombre { get; set; }

        [Display(Name = "Plan Membresia")]
        public string? PlanMembresiaNombre { get; set; }

        [Display(Name = "Municipio")]
        public string? MunicipioNombre { get; set; }
    }
}
