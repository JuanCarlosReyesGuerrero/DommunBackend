using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ICaracteristicaParqueaderoRepository
    {
        Task<Result> GetAllCaracteristicaParqueaderos();
        Task<Result> GetCaracteristicaParqueaderoById(int Id);
        Task<Result> InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
        Task<Result> UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
        Task<Result> DeleteCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
    }
}

