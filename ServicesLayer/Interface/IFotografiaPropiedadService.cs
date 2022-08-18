using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IFotografiaPropiedadService
    {
        IEnumerable<FotografiaPropiedad> GetAllFotografiaPropiedades();
        FotografiaPropiedad GetFotografiaPropiedadById(int id);
        void InsertFotografiaPropiedad(FotografiaPropiedad model);
        void UpdateFotografiaPropiedad(FotografiaPropiedad model);
        void DeleteFotografiaPropiedad(int id);
    }
}
