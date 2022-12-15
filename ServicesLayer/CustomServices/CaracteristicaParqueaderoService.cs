using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class CaracteristicaParqueaderoService : ICaracteristicaParqueaderoService
    {
        private readonly ICaracteristicaParqueaderoRepository caracteristicaparqueaderoRepository;

        public CaracteristicaParqueaderoService(ICaracteristicaParqueaderoRepository _caracteristicaparqueaderoRepository)
        {
            this.caracteristicaparqueaderoRepository = _caracteristicaparqueaderoRepository;
        }

        public Task<Result> DeleteCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity)
        {
            return caracteristicaparqueaderoRepository.DeleteCaracteristicaParqueadero(entity);
        }

        public Task<Result> GetCaracteristicaParqueaderoById(int Id)
        {
            return caracteristicaparqueaderoRepository.GetCaracteristicaParqueaderoById(Id);
        }

        public Task<Result> GetAllCaracteristicaParqueaderos()
        {
            return caracteristicaparqueaderoRepository.GetAllCaracteristicaParqueaderos();
        }

        public Task<Result> InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity)
        {
            return caracteristicaparqueaderoRepository.InsertCaracteristicaParqueadero(entity);
        }

        public Task<Result> UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity)
        {
            return caracteristicaparqueaderoRepository.UpdateCaracteristicaParqueadero(entity);
        }
    }
}

