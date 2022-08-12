using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IAuthToken
    {
        string GenerarToken(AuthModel authModel);
    }
}
