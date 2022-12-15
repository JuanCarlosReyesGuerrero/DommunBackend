using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ITipoParqueaderoService
    {
        Task<Result> GetAllTipoParqueaderos();
        Task<Result> GetTipoParqueaderoById(int Id);
        Task<Result> InsertTipoParqueadero(TipoParqueaderoDto entity);
        Task<Result> UpdateTipoParqueadero(TipoParqueaderoDto entity);
        Task<Result> DeleteTipoParqueadero(TipoParqueaderoDto entity);
    }
}
