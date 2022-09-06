using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IBackOfficeRepository
    {
        Task<Result> ValidarLogin(LoginModel objModel);
        Task<Result> Registro(LoginModel objModel);
        Task<Result> CambioPassword(ChangePasswordModel objModel);
    }
}
