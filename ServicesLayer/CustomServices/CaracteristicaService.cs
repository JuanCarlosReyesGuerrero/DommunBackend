using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class CaracteristicaService : ICaracteristicaService
    {
        private readonly ICaracteristicaRepository caracteristicaRepository;

        public CaracteristicaService(ICaracteristicaRepository _caracteristicaRepository)
        {
            this.caracteristicaRepository = _caracteristicaRepository;
        }

        public Task<Result> DeleteCaracteristica(CaracteristicaDto entity)
        {
            return caracteristicaRepository.DeleteCaracteristica(entity);
        }

        public Task<Result> GetCaracteristicaById(int Id)
        {
            return caracteristicaRepository.GetCaracteristicaById(Id);
        }

        public Task<Result> GetAllCaracteristicas()
        {
            return caracteristicaRepository.GetAllCaracteristicas();
        }

        public Task<Result> InsertCaracteristica(CaracteristicaDto entity)
        {
            return caracteristicaRepository.InsertCaracteristica(entity);
        }

        public Task<Result> UpdateCaracteristica(CaracteristicaDto entity)
        {
            return caracteristicaRepository.UpdateCaracteristica(entity);
        }
    }
}

