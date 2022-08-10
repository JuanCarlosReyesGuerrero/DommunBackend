using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunBackend.DomainLayer.DTOs
{
    public class PlanMembresiaDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Precio Promoción")]
        public decimal PrecioPromocion { get; set; }

        [Display(Name = "Precio Fijo")]
        public decimal PrecioFijo { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}
