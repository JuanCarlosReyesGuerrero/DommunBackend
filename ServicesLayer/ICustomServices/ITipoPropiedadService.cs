using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface ITipoPropiedadService
    {
        IEnumerable<TipoPropiedad> GetAllTipoPropiedades();
        TipoPropiedad GetTipoPropiedadById(int id);
        void InsertTipoPropiedad(TipoPropiedad model);
        void UpdateTipoPropiedad(TipoPropiedad model);
        void DeleteTipoPropiedad(int id);
    }
}
