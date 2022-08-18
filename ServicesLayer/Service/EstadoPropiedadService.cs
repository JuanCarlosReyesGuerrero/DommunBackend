using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class EstadoPropiedadService : IEstadoPropiedadService
    {
        #region Property  
        private readonly IRepository<EstadoPropiedad> objRepository;
        #endregion

        #region Constructor  
        public EstadoPropiedadService(IRepository<EstadoPropiedad> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteEstadoPropiedad(int id)
        {
            EstadoPropiedad customer = GetEstadoPropiedadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public EstadoPropiedad GetEstadoPropiedadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<EstadoPropiedad> GetAllEstadoPropiedades()
        {
            return objRepository.GetAll();
        }

        public void InsertEstadoPropiedad(EstadoPropiedad model)
        {
            objRepository.Insert(model);
        }

        public void UpdateEstadoPropiedad(EstadoPropiedad model)
        {
            objRepository.Update(model);
        }
    }
}
