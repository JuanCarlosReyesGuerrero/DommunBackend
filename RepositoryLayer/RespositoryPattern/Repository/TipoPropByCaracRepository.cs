using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.Repository
{
    public interface TipoPropByCaracRepository
    {
        Task<Result> GetAllTipoParqueaderos();
        Task<Result> GetTipoParqueaderoById(int Id);
        Task<Result> InsertTipoParqueadero(TipoPropiedadByCaracteristica entity);
        Task<Result> UpdateTipoParqueadero(TipoParqueaderoDto entity);
        Task<Result> DeleteTipoParqueadero(TipoParqueaderoDto entity);
    }
}
