using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class TipoCaracteristicaService : ITipoCaracteristicaService
    {
        private readonly ITipoCaracteristicaRepository tipocaracteristicaRepository;

        public TipoCaracteristicaService(ITipoCaracteristicaRepository _tipocaracteristicaRepository)
        {
            this.tipocaracteristicaRepository = _tipocaracteristicaRepository;
        }

        public Task<Result> DeleteTipoCaracteristica(TipoCaracteristicaDto entity)
        {
            return tipocaracteristicaRepository.DeleteTipoCaracteristica(entity);
        }

        public Task<Result> GetTipoCaracteristicaById(int Id)
        {
            return tipocaracteristicaRepository.GetTipoCaracteristicaById(Id);
        }

        public Task<Result> GetAllTipoCaracteristicas()
        {
            return tipocaracteristicaRepository.GetAllTipoCaracteristicas();
        }

        public Task<Result> InsertTipoCaracteristica(TipoCaracteristicaDto entity)
        {
            return tipocaracteristicaRepository.InsertTipoCaracteristica(entity);
        }

        public Task<Result> UpdateTipoCaracteristica(TipoCaracteristicaDto entity)
        {
            return tipocaracteristicaRepository.UpdateTipoCaracteristica(entity);
        }
    }
}

