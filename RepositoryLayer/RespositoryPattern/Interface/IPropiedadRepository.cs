using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.Interface
{
    public interface IPropiedadRepository
    {
        Task<Result> ObtenerPropiedades();
    }
}
