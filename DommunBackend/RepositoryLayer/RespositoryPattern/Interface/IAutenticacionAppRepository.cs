using DommunBackend.DomainLayer.Models;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.Interface
{
    public interface IAutenticacionAppRepository : IDisposable
    {
        bool ObtenerListPermissions(ApplicationDbModel entity);       
    }
}
