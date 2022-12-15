using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class TipoOfertaService : ITipoOfertaService
    {
        private readonly ITipoOfertaRepository tipoofertaRepository;

        public TipoOfertaService(ITipoOfertaRepository _tipoofertaRepository)
        {
            this.tipoofertaRepository = _tipoofertaRepository;
        }

        public Task<Result> DeleteTipoOferta(TipoOfertaDto entity)
        {
            return tipoofertaRepository.DeleteTipoOferta(entity);
        }

        public Task<Result> GetTipoOfertaById(int Id)
        {
            return tipoofertaRepository.GetTipoOfertaById(Id);
        }

        public Task<Result> GetAllTipoOfertas()
        {
            return tipoofertaRepository.GetAllTipoOfertas();
        }

        public Task<Result> InsertTipoOferta(TipoOfertaDto entity)
        {
            return tipoofertaRepository.InsertTipoOferta(entity);
        }

        public Task<Result> UpdateTipoOferta(TipoOfertaDto entity)
        {
            return tipoofertaRepository.UpdateTipoOferta(entity);
        }
    }
}

