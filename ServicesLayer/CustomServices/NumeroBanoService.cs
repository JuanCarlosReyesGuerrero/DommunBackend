using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class NumeroBanoService : INumeroBanoService
    {
        private readonly INumeroBanoRepository numerobanoRepository;

        public NumeroBanoService(INumeroBanoRepository _numerobanoRepository)
        {
            this.numerobanoRepository = _numerobanoRepository;
        }

        public Task<Result> DeleteNumeroBano(NumeroBanoDto entity)
        {
            return numerobanoRepository.DeleteNumeroBano(entity);
        }

        public Task<Result> GetNumeroBanoById(int Id)
        {
            return numerobanoRepository.GetNumeroBanoById(Id);
        }

        public Task<Result> GetAllNumeroBanos()
        {
            return numerobanoRepository.GetAllNumeroBanos();
        }

        public Task<Result> InsertNumeroBano(NumeroBanoDto entity)
        {
            return numerobanoRepository.InsertNumeroBano(entity);
        }

        public Task<Result> UpdateNumeroBano(NumeroBanoDto entity)
        {
            return numerobanoRepository.UpdateNumeroBano(entity);
        }
    }
}

