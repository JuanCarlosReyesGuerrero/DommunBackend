using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ITipoCaracteristicaRepository
    {
        Task<Result> GetAllTipoCaracteristicas();
        Task<Result> GetTipoCaracteristicaById(int Id);
        Task<Result> InsertTipoCaracteristica(TipoCaracteristicaDto entity);
        Task<Result> UpdateTipoCaracteristica(TipoCaracteristicaDto entity);
        Task<Result> DeleteTipoCaracteristica(TipoCaracteristicaDto entity);
    }
}

