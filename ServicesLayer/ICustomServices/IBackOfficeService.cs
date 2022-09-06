using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IBackOfficeService
    {
       Task<Result> ValidarLogin(LoginModel loginModel);
        Task<Result> Registro(LoginModel objModel);
        Task<Result> CambioPassword(ChangePasswordModel objModel);
    }
}
