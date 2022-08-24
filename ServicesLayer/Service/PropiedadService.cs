using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class PropiedadService : IPropiedadService
    {
        #region Property  
        private readonly IRepository<Propiedad> objRepository;
        private readonly IPropiedadRepository propiedadRepository;
        #endregion

        #region Constructor  
        public PropiedadService(IRepository<Propiedad> _objRepository,IPropiedadRepository _propiedadRepository)
        {
            this.objRepository = _objRepository;
            this.propiedadRepository = _propiedadRepository;
        }
        #endregion

        public void DeletePropiedad(int id)
        {
            Propiedad customer = GetPropiedadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Propiedad GetPropiedadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Propiedad> GetAllPropiedades()
        {
            return objRepository.GetAll();
        }

        public void InsertPropiedad(Propiedad model)
        {
            objRepository.Insert(model);
        }

        public void UpdatePropiedad(Propiedad model)
        {
            objRepository.Update(model);
        }

        public Task<Result> ObtenerPropiedades()
        {
            return propiedadRepository.ObtenerPropiedades();
        }

        public Task<Result> ObtenerPropiedadesById(int vId)
        {
            return propiedadRepository.ObtenerPropiedadesById(vId);
        }
    }
}
