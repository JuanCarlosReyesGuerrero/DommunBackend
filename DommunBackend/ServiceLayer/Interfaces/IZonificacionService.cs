using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IZonificacionService
    {
        IEnumerable<Zonificacion> GetAllZonificaciones();
        Zonificacion GetZonificacionById(int? id);
        void InsertZonificacion(Zonificacion entity);
        void UpdateZonificacion(Zonificacion entity);
        void DeleteZonificacion(int? id);
    }
}
