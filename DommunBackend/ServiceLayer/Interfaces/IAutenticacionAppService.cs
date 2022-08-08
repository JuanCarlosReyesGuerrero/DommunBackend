using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IAutenticacionAppService
    {
        bool ObtenerListPermissions(ApplicationDbModel entity);
    }
}
