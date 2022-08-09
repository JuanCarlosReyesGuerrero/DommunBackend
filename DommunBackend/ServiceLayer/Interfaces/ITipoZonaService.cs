﻿using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface ITipoZonaService
    {
        IEnumerable<TipoZona> GetAllTipoZonas();
        TipoZona GetTipoZonaById(int id);
        void InsertTipoZona(TipoZona tipoZona);
        void UpdateTipoZona(TipoZona tipoZona);
        void DeleteTipoZona(int id);
    }
}