using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.Interface
{
    public interface IPropiedadRepository
    {
        Task<Result> ObtenerPropiedades();
        Task<Result> ObtenerPropiedadesById(int vId);
    }
}
