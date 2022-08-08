using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class AutenticacionAppService: IAutenticacionAppService
    {        
        private IAutenticacionAppRepository objRepository;

        public AutenticacionAppService(IAutenticacionAppRepository _objRepository)
        {           
            this.objRepository = _objRepository;
        }

        public bool ObtenerListPermissions(ApplicationDbModel entity)
        {
            return objRepository.ObtenerListPermissions(entity);
        }
    }
}
