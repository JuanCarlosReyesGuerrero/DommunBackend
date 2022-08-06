using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class MunicipioDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Departamento")]
        public string? DepartamentoNombre { get; set; }

        public int DepartamentoId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}

