using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ICaracteristicaService
    {
        Task<Result> GetAllCaracteristicas();
        Task<Result> GetCaracteristicaById(int Id);
        Task<Result> InsertCaracteristica(CaracteristicaDto entity);
        Task<Result> UpdateCaracteristica(CaracteristicaDto entity);
        Task<Result> DeleteCaracteristica(CaracteristicaDto entity);
    }
}

