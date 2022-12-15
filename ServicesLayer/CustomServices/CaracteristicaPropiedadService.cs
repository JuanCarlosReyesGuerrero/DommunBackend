using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class CaracteristicaPropiedadService : ICaracteristicaPropiedadService
    {
        private readonly ICaracteristicaPropiedadRepository caracteristicapropiedadRepository;

        public CaracteristicaPropiedadService(ICaracteristicaPropiedadRepository _caracteristicapropiedadRepository)
        {
            this.caracteristicapropiedadRepository = _caracteristicapropiedadRepository;
        }

        public Task<Result> DeleteCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            return caracteristicapropiedadRepository.DeleteCaracteristicaPropiedad(entity);
        }

        public Task<Result> GetCaracteristicaPropiedadById(int Id)
        {
            return caracteristicapropiedadRepository.GetCaracteristicaPropiedadById(Id);
        }

        public Task<Result> GetAllCaracteristicaPropiedades()
        {
            return caracteristicapropiedadRepository.GetAllCaracteristicaPropiedades();
        }

        public Task<Result> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            return caracteristicapropiedadRepository.InsertCaracteristicaPropiedad(entity);
        }

        public Task<Result> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            return caracteristicapropiedadRepository.UpdateCaracteristicaPropiedad(entity);
        }
    }
}

