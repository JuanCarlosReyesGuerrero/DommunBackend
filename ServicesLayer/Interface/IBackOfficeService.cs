using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IBackOfficeService
    {
       Task<Result> ValidarLogin(LoginModel loginModel);
    }
}
