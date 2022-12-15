using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ICaracteristicaPropiedadRepository
    {
        Task<Result> GetAllCaracteristicaPropiedades();
        Task<Result> GetCaracteristicaPropiedadById(int Id);
        Task<Result> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
        Task<Result> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
        Task<Result> DeleteCaracteristicaPropiedad(CaracteristicaPropiedadDto entity);
    }
}

