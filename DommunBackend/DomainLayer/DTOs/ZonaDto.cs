using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.DTOs
{
    public class ZonaDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Slug")]
        public string? Slug { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}
