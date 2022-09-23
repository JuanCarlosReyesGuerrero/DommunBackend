using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IAgenteRepository
    {
        Task<Result> ObtenerAgentes();
        Task<Result> ObtenerAgenteById(int vId);
    }
}
