using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class TiempoConstruidoService : ITiempoConstruidoService
    {
        private readonly ITiempoConstruidoRepository tiempoconstruidoRepository;

        public TiempoConstruidoService(ITiempoConstruidoRepository _tiempoconstruidoRepository)
        {
            this.tiempoconstruidoRepository = _tiempoconstruidoRepository;
        }

        public Task<Result> DeleteTiempoConstruido(TiempoConstruidoDto entity)
        {
            return tiempoconstruidoRepository.DeleteTiempoConstruido(entity);
        }

        public Task<Result> GetTiempoConstruidoById(int Id)
        {
            return tiempoconstruidoRepository.GetTiempoConstruidoById(Id);
        }

        public Task<Result> GetAllTiempoConstruidos()
        {
            return tiempoconstruidoRepository.GetAllTiempoConstruidos();
        }

        public Task<Result> InsertTiempoConstruido(TiempoConstruidoDto entity)
        {
            return tiempoconstruidoRepository.InsertTiempoConstruido(entity);
        }

        public Task<Result> UpdateTiempoConstruido(TiempoConstruidoDto entity)
        {
            return tiempoconstruidoRepository.UpdateTiempoConstruido(entity);
        }
    }
}

