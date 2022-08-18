using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class FotografiaPropiedadService : IFotografiaPropiedadService
    {
        #region Property  
        private readonly IRepository<FotografiaPropiedad> objRepository;
        #endregion

        #region Constructor  
        public FotografiaPropiedadService(IRepository<FotografiaPropiedad> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteFotografiaPropiedad(int id)
        {
            FotografiaPropiedad customer = GetFotografiaPropiedadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public FotografiaPropiedad GetFotografiaPropiedadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<FotografiaPropiedad> GetAllFotografiaPropiedades()
        {
            return objRepository.GetAll();
        }

        public void InsertFotografiaPropiedad(FotografiaPropiedad model)
        {
            objRepository.Insert(model);
        }

        public void UpdateFotografiaPropiedad(FotografiaPropiedad model)
        {
            objRepository.Update(model);
        }
    }
}
