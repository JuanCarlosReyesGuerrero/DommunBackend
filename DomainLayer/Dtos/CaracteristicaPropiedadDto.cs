using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DomainLayer.Dtos
{
    public class CaracteristicaPropiedadDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Display(Name = "PropiedadId")]
        public int? PropiedadId { get; set; }

        [Display(Name = "CaracteristicaId")]
        public int? CaracteristicaId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
