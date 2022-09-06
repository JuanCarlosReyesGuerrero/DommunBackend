using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class CiudadService : ICiudadService
    {
        #region Property  
        private readonly IRepository<Ciudad> objRepository;
        #endregion

        #region Constructor  
        public CiudadService(IRepository<Ciudad> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteCiudad(int id)
        {
            Ciudad customer = GetCiudadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Ciudad GetCiudadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Ciudad> GetAllCiudades()
        {
            return objRepository.GetAll();
        }

        public void InsertCiudad(Ciudad model)
        {
            objRepository.Insert(model);
        }

        public void UpdateCiudad(Ciudad model)
        {
            objRepository.Update(model);
        }
    }
}
