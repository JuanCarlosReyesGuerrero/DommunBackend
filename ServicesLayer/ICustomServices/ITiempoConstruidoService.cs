using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ITiempoConstruidoService
    {
        Task<Result> GetAllTiempoConstruidos();
        Task<Result> GetTiempoConstruidoById(int Id);
        Task<Result> InsertTiempoConstruido(TiempoConstruidoDto entity);
        Task<Result> UpdateTiempoConstruido(TiempoConstruidoDto entity);
        Task<Result> DeleteTiempoConstruido(TiempoConstruidoDto entity);
    }
}
