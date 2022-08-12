using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.Interface
{
    public interface IBackOfficeRepository
    {
        Task<Result> ValidarLogin(LoginModel loginModel);
    }
}
