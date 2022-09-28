using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IPropiedadService
    {
        Task<Result> GetAllPropiedades();
        Task<Result> GetPropiedadById(int Id);
        Task<Result> InsertPropiedad(PropiedadDto entity);
        Task<Result> UpdatePropiedad(PropiedadDto entity);
        Task<Result> DeletePropiedad(PropiedadDto entity);      
    }
}
