using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class CaracteristicaDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }
  
        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }
        
        [Display(Name = "TipoCaracteristicaId")]
        public int? TipoCaracteristicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }        
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
        
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
