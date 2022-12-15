using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface INumeroParqueaderoService
    {
        Task<Result> GetAllNumeroParqueaderos();
        Task<Result> GetNumeroParqueaderoById(int Id);
        Task<Result> InsertNumeroParqueadero(NumeroParqueaderoDto entity);
        Task<Result> UpdateNumeroParqueadero(NumeroParqueaderoDto entity);
        Task<Result> DeleteNumeroParqueadero(NumeroParqueaderoDto entity);
    }
}
