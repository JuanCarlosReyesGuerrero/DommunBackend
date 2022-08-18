using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class FotografiaService : IFotografiaService
    {
        #region Property  
        private readonly IRepository<Fotografia> objRepository;
        #endregion

        #region Constructor  
        public FotografiaService(IRepository<Fotografia> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteFotografia(int id)
        {
            Fotografia customer = GetFotografiaById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Fotografia GetFotografiaById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Fotografia> GetAllFotografias()
        {
            return objRepository.GetAll();
        }

        public void InsertFotografia(Fotografia model)
        {
            objRepository.Insert(model);
        }

        public void UpdateFotografia(Fotografia model)
        {
            objRepository.Update(model);
        }
    }
}
