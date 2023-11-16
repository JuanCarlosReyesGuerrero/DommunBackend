using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IAgenteRepository
    {
        Task<Result> GetAllAgentes();
        Task<Result> GetAgenteById(int Id);
        Task<Result> InsertAgente(AgenteCreacionDto entity);
        Task<Result> UpdateAgente(AgenteCreacionDto entity);
        Task<Result> DeleteAgente(AgenteDto entity);      
                
        Task<Result> ObtenerAgentesFull();
        Task<Result> ObtenerAgenteFullById(int vId);
    }
}
