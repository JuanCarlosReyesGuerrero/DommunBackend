using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IPropiedadRepository
    {
        Task<Result> ObtenerPropiedades();
        Task<Result> ObtenerPropiedadById(int vId);
    }
}
