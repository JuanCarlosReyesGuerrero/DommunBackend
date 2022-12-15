using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ITipoParqueaderoRepository
    {
        Task<Result> GetAllTipoParqueaderos();
        Task<Result> GetTipoParqueaderoById(int Id);
        Task<Result> InsertTipoParqueadero(TipoParqueaderoDto entity);
        Task<Result> UpdateTipoParqueadero(TipoParqueaderoDto entity);
        Task<Result> DeleteTipoParqueadero(TipoParqueaderoDto entity);
    }
}

