using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IBackOfficeService
    {
       Task<Result> ValidarLogin(LoginModel loginModel);
    }
}
