using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class AgenteDto
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Slug")]
        public string? Slug { get; set; }

        [Display(Name = "Nombres")]
        public string? Nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string? Apellidos { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Foto Perfil")]
        public string? FotoPerfil { get; set; }

        [Display(Name = "Descripción Perfil")]
        public string? DescripcionPerfil { get; set; }

        [Display(Name = "Celular")]
        public string? Celular { get; set; }

        [Display(Name = "Inmobiliaria")]
        public int InmobiliariaId { get; set; }

        [Display(Name = "Facebook")]
        public string? Facebook { get; set; }

        [Display(Name = "Twitter")]
        public string? Twitter { get; set; }

        [Display(Name = "Linkedin")]
        public string? Linkedin { get; set; }

        [Display(Name = "Instagram")]
        public string? Instagram { get; set; }

        [Display(Name = "Website")]
        public string? Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}
