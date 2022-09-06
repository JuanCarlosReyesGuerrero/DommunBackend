using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class TipoPropiedadService : ITipoPropiedadService
    {
        #region Property  
        private readonly IRepository<TipoPropiedad> objRepository;
        #endregion

        #region Constructor  
        public TipoPropiedadService(IRepository<TipoPropiedad> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteTipoPropiedad(int id)
        {
            TipoPropiedad customer = GetTipoPropiedadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public TipoPropiedad GetTipoPropiedadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<TipoPropiedad> GetAllTipoPropiedades()
        {
            return objRepository.GetAll();
        }

        public void InsertTipoPropiedad(TipoPropiedad model)
        {
            objRepository.Insert(model);
        }

        public void UpdateTipoPropiedad(TipoPropiedad model)
        {
            objRepository.Update(model);
        }
    }
}
