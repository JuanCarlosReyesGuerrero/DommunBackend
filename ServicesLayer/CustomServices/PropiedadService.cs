using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class PropiedadService : IPropiedadService
    {
        private readonly IPropiedadRepository propiedadRepository;

        public PropiedadService(IRepository<Propiedad> _objRepository, IPropiedadRepository _propiedadRepository)
        {
            this.propiedadRepository = _propiedadRepository;
        }

        public Task<Result> DeletePropiedad(PropiedadDto entity)
        {
            return propiedadRepository.DeletePropiedad(entity);
        }

        public Task<Result> GetAllPropiedades()
        {
            return propiedadRepository.GetAllPropiedades();
        }

        public Task<Result> GetPropiedadById(int Id)
        {
            return propiedadRepository.GetPropiedadById(Id);
        }

        public Task<Result> InsertPropiedad(PropiedadDto entity)
        {
            return propiedadRepository.InsertPropiedad(entity);
        }       

        public Task<Result> UpdatePropiedad(PropiedadDto entity)
        {
            return propiedadRepository.UpdatePropiedad(entity);
        }
    }
}
