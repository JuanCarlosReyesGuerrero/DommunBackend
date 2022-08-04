using DomainLayer.DTOs;
using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IAuthToken
    {
        string GenerarToken(AuthModel authModel);
    }
}
