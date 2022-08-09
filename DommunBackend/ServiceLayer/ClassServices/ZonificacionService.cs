using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class ZonificacionService : IZonificacionService
    {
        private IRepository<Zonificacion> objRepository;

        public ZonificacionService(IRepository<Zonificacion> _objRepository)
        {
            this.objRepository = _objRepository;
        }

        public void DeleteZonificacion(int? id)
        {
            Zonificacion objModel = GetZonificacionById(id);
            objRepository.Remove(objModel);
            objRepository.SaveChanges();
        }

        public IEnumerable<Zonificacion> GetAllZonificaciones()
        {
            return objRepository.GetAll();
        }

        public Zonificacion GetZonificacionById(int? id)
        {
            return objRepository.GetById(id);
        }

        public void InsertZonificacion(Zonificacion objModel)
        {
            objRepository.Insert(objModel);
        }

        public void UpdateZonificacion(Zonificacion objModel)
        {
            objRepository.Update(objModel);
        }
    }
}
