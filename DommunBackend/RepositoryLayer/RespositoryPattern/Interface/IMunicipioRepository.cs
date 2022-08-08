using DommunBackend.DomainLayer.DTOs;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.Interface
{
    public interface IMunicipioRepository : IDisposable
    {
        List<MunicipioDto> ObtenerMunicipioByDepartamento();
    }
}
