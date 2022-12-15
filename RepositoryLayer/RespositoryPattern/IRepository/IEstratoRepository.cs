using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IEstratoRepository
    {
        Task<Result> GetAllEstratos();
        Task<Result> GetEstratoById(int Id);
        Task<Result> InsertEstrato(EstratoDto entity);
        Task<Result> UpdateEstrato(EstratoDto entity);
        Task<Result> DeleteEstrato(EstratoDto entity);
    }
}

