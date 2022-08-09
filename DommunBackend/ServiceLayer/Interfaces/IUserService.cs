using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> FindByEmail(string email);

        Task<ApplicationUser> GetUserIdentity(string email, string password);
    }
}
