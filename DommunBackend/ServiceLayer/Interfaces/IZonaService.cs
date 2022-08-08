using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IZonaService
    {
        IEnumerable<Zona> GetAllZonas();
        Zona GetZonaById(int id);
        void InsertZona(Zona zona);
        void UpdateZona(Zona zona);
        void DeleteZona(int id);
    }
}
