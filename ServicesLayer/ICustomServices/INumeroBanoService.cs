using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface INumeroBanoService
    {
        Task<Result> GetAllNumeroBanos();
        Task<Result> GetNumeroBanoById(int Id);
        Task<Result> InsertNumeroBano(NumeroBanoDto entity);
        Task<Result> UpdateNumeroBano(NumeroBanoDto entity);
        Task<Result> DeleteNumeroBano(NumeroBanoDto entity);
    }
}

