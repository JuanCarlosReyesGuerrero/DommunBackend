﻿using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class AgenteFullDto
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


        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }


        public Inmobiliaria? Inmobiliaria { get; set; }

        public List<PropiedadFullDto>? Propiedades { get; set; }     
    }
}