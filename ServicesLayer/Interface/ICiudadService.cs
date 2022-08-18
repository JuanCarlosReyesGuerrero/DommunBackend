using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface ICiudadService
    {
        IEnumerable<Ciudad> GetAllCiudades();
        Ciudad GetCiudadById(int id);
        void InsertCiudad(Ciudad model);
        void UpdateCiudad(Ciudad model);
        void DeleteCiudad(int id);
    }
}
