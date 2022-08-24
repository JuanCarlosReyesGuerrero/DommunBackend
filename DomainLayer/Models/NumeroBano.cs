﻿namespace DomainLayer.Models
{
    public class NumeroBano : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
