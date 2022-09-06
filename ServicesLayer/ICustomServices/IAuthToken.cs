using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IAuthToken
    {
        string GenerarToken(AuthModel authModel);
    }
}
