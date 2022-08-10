using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.DTOs
{
    public class ZonificacionDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}
