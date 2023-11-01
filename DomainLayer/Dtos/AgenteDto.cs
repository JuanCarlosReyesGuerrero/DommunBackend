using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DomainLayer.Dtos
{
    public class AgenteDto
    {
        [HiddenInput]
        public int Id { get; set; }

        public string? Slug { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? FotoPerfil { get; set; }
        public string? DescripcionPerfil { get; set; }
        public string? Celular { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? Instagram { get; set; }
        public string? Website { get; set; }
        public int? InmobiliariaId { get; set; }  
        //public IFormFile? Foto { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "fullName")]
        public string fullName
        {
            get
            {
                return Nombres + " " + Apellidos;
            }
        }

        public InmobiliariaDto? Inmobiliaria { get; set; }        
    }
}
