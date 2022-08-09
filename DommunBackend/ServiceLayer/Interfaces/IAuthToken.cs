using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IAuthToken
    {
        string GenerarToken(AuthModel authModel);
    }
}
