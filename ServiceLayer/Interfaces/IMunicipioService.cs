using DomainLayer.DTOs;
using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IMunicipioService
    {
        IEnumerable<Municipio> GetAllMunicipios();
        Municipio GetMunicipioById(int id);
        void InsertMunicipio(Municipio municipio);
        void UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int id);

        List<MunicipioDto> ObtenerMunicipioByDepartamento();
    }
}
