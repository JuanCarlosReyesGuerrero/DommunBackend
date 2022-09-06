using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IInmobiliariaService
    {
        IEnumerable<Inmobiliaria> GetAllInmobiliarias();
        Inmobiliaria GetInmobiliariaById(int id);
        void InsertInmobiliaria(Inmobiliaria model);
        void UpdateInmobiliaria(Inmobiliaria model);
        void DeleteInmobiliaria(int id);
    }
}
