using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IPropiedadRepository
    {
        Task<Result> GetAllPropiedades();
        Task<Result> GetPropiedadById(int Id);
        Task<Result> InsertPropiedad(PropiedadDto entity);
        Task<Result> UpdatePropiedad(PropiedadDto entity);
        Task<Result> DeletePropiedad(PropiedadDto entity);        
    }
}
