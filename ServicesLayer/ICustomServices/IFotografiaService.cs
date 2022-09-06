using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IFotografiaService
    {
        IEnumerable<Fotografia> GetAllFotografias();
        Fotografia GetFotografiaById(int id);
        void InsertFotografia(Fotografia model);
        void UpdateFotografia(Fotografia model);
        void DeleteFotografia(int id);
    }
}
