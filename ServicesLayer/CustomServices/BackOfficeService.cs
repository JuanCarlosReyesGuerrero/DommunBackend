using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class BackOfficeService : IBackOfficeService
    {
        private readonly IBackOfficeRepository objRepository;

        public BackOfficeService(IBackOfficeRepository _objRepository)
        {
            this.objRepository = _objRepository;
        }

        Task<Result> IBackOfficeService.ValidarLogin(LoginModel loginModel)
        {
            return objRepository.ValidarLogin(loginModel);
        }
    }
}
