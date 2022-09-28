using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class AgenteService : IAgenteService
    {
        private readonly IAgenteRepository agenteRepository;

        public AgenteService(IAgenteRepository _agenteRepository)
        {
            this.agenteRepository = _agenteRepository;
        }

        public Task<Result> DeleteAgente(AgenteDto entity)
        {
            return agenteRepository.DeleteAgente(entity);
        }

        public Task<Result> GetAgenteById(int Id)
        {
            return agenteRepository.GetAgenteById(Id);
        }

        public Task<Result> GetAllAgentes()
        {
            return agenteRepository.GetAllAgentes();
        }

        public Task<Result> InsertAgente(AgenteDto entity)
        {
            return agenteRepository.InsertAgente(entity);
        }

        public Task<Result> ObtenerAgenteFullById(int vId)
        {
            return agenteRepository.ObtenerAgenteFullById(vId);
        }

        public Task<Result> ObtenerAgentesFull()
        {
            return agenteRepository.ObtenerAgentesFull();
        }

        public Task<Result> UpdateAgente(AgenteDto entity)
        {
            return agenteRepository.UpdateAgente(entity);
        }
    }
}