using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IPropiedadService
    {
        IEnumerable<Propiedad> GetAllPropiedades();
        Propiedad GetPropiedadById(int id);
        void InsertPropiedad(Propiedad model);
        void UpdatePropiedad(Propiedad model);
        void DeletePropiedad(int id);

        Task<Result> ObtenerPropiedades();
    }
}
