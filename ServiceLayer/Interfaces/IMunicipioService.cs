using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IMunicipioService
    {
        IEnumerable<Municipio> GetAllMunicipios();
        Municipio GetMunicipio(int id);
        void InsertMunicipio(Municipio municipio);
        void UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int id);
    }
}
