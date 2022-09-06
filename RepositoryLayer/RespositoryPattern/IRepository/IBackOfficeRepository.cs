using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface IBackOfficeRepository
    {
        Task<Result> ValidarLogin(LoginModel loginModel);
    }
}
