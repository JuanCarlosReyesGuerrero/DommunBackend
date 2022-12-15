using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ICaracteristicaPropiedadService
    {
        Task<Result> GetAllCaracteristicaPropiedades();
        Task<Result> GetCaracteristicaPropiedadById(int Id);
        Task<Result> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
        Task<Result> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
        Task<Result> DeleteCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
    }
}

