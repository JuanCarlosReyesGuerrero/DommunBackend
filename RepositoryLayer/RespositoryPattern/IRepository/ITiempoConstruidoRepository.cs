using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ITiempoConstruidoRepository
    {
        Task<Result> GetAllTiempoConstruidos();
        Task<Result> GetTiempoConstruidoById(int Id);
        Task<Result> InsertTiempoConstruido(TiempoConstruidoDto entity);
        Task<Result> UpdateTiempoConstruido(TiempoConstruidoDto entity);
        Task<Result> DeleteTiempoConstruido(TiempoConstruidoDto entity);
    }
}

