﻿using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IEstadoPropiedadService
    {
        IEnumerable<EstadoPropiedad> GetAllEstadoPropiedades();
        EstadoPropiedad GetEstadoPropiedadById(int id);
        void InsertEstadoPropiedad(EstadoPropiedad model);
        void UpdateEstadoPropiedad(EstadoPropiedad model);
        void DeleteEstadoPropiedad(int id);
    }
}
