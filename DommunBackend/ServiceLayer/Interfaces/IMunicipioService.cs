using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IMunicipioService
    {
        IEnumerable<Municipio> GetAllMunicipios();
        Municipio GetMunicipioById(int? id);
        void InsertMunicipio(Municipio municipio);
        void UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int? id);

        List<MunicipioDto> ObtenerMunicipioByDepartamento();
    }
}