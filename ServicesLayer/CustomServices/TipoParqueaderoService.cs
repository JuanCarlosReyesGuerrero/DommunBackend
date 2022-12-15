using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class TipoParqueaderoService : ITipoParqueaderoService
    {
        private readonly ITipoParqueaderoRepository tipoparqueaderoRepository;

        public TipoParqueaderoService(ITipoParqueaderoRepository _tipoparqueaderoRepository)
        {
            this.tipoparqueaderoRepository = _tipoparqueaderoRepository;
        }

        public Task<Result> DeleteTipoParqueadero(TipoParqueaderoDto entity)
        {
            return tipoparqueaderoRepository.DeleteTipoParqueadero(entity);
        }

        public Task<Result> GetTipoParqueaderoById(int Id)
        {
            return tipoparqueaderoRepository.GetTipoParqueaderoById(Id);
        }

        public Task<Result> GetAllTipoParqueaderos()
        {
            return tipoparqueaderoRepository.GetAllTipoParqueaderos();
        }

        public Task<Result> InsertTipoParqueadero(TipoParqueaderoDto entity)
        {
            return tipoparqueaderoRepository.InsertTipoParqueadero(entity);
        }

        public Task<Result> UpdateTipoParqueadero(TipoParqueaderoDto entity)
        {
            return tipoparqueaderoRepository.UpdateTipoParqueadero(entity);
        }
    }
}

