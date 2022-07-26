﻿using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface ITipoZonaService
    {
        IEnumerable<TipoZona> GetAllTipoZonas();
        TipoZona GetTipoZona(int id);
        void InsertTipoZona(TipoZona tipoZona);
        void UpdateTipoZona(TipoZona tipoZona);
        void DeleteTipoZona(int id);
    }
}
