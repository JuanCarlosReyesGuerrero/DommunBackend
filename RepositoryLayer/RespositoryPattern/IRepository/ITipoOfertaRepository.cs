using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface ITipoOfertaRepository
    {
        Task<Result> GetAllTipoOfertas();
        Task<Result> GetTipoOfertaById(int Id);
        Task<Result> InsertTipoOferta(TipoOfertaDto entity);
        Task<Result> UpdateTipoOferta(TipoOfertaDto entity);
        Task<Result> DeleteTipoOferta(TipoOfertaDto entity);
    }
}

