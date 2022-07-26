﻿using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class TipoZonaService : ITipoZonaService
    {
        private IRepository<TipoZona> tipoZonaRepository;

        public TipoZonaService(IRepository<TipoZona> _tipoZonaRepository)
        {
            this.tipoZonaRepository = _tipoZonaRepository;
        }

        public void DeleteTipoZona(int id)
        {
            TipoZona tipoZona = GetTipoZona(id);
            tipoZonaRepository.Remove(tipoZona);
            tipoZonaRepository.SaveChanges();
        }

        public IEnumerable<TipoZona> GetAllTipoZonas()
        {
            return tipoZonaRepository.GetAll();
        }

        public TipoZona GetTipoZona(int id)
        {
            return tipoZonaRepository.Get(id);
        }

        public void InsertTipoZona(TipoZona tipoZona)
        {
            tipoZonaRepository.Insert(tipoZona);
        }

        public void UpdateTipoZona(TipoZona tipoZona)
        {
            tipoZonaRepository.Update(tipoZona);
        }
    }
}