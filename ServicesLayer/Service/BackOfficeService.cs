using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
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
