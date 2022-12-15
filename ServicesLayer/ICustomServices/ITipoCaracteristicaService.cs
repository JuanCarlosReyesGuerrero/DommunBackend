using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ITipoCaracteristicaService
    {
        Task<Result> GetAllTipoCaracteristicas();
        Task<Result> GetTipoCaracteristicaById(int Id);
        Task<Result> InsertTipoCaracteristica(TipoCaracteristicaDto entity);
        Task<Result> UpdateTipoCaracteristica(TipoCaracteristicaDto entity);
        Task<Result> DeleteTipoCaracteristica(TipoCaracteristicaDto entity);
    }
}
