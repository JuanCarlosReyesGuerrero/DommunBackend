using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IPropiedadService
    {
        IEnumerable<Propiedad> GetAllPropiedades();
        Propiedad GetPropiedadById(int id);
        void InsertPropiedad(Propiedad model);
        void UpdatePropiedad(Propiedad model);
        void DeletePropiedad(int id);

        Task<Result> ObtenerPropiedades();
        Task<Result> ObtenerPropiedadById(int vId);
    }
}
