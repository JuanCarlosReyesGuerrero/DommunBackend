using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class EstratoService : IEstratoService
    {
        private readonly IEstratoRepository estratoRepository;

        public EstratoService(IEstratoRepository _estratoRepository)
        {
            this.estratoRepository = _estratoRepository;
        }

        public Task<Result> DeleteEstrato(EstratoDto entity)
        {
            return estratoRepository.DeleteEstrato(entity);
        }

        public Task<Result> GetEstratoById(int Id)
        {
            return estratoRepository.GetEstratoById(Id);
        }

        public Task<Result> GetAllEstratos()
        {
            return estratoRepository.GetAllEstratos();
        }

        public Task<Result> InsertEstrato(EstratoDto entity)
        {
            return estratoRepository.InsertEstrato(entity);
        }

        public Task<Result> UpdateEstrato(EstratoDto entity)
        {
            return estratoRepository.UpdateEstrato(entity);
        }
    }
}

