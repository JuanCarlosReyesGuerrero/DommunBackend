using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class NumeroParqueaderoService : INumeroParqueaderoService
    {
        private readonly INumeroParqueaderoRepository numeroparqueaderoRepository;

        public NumeroParqueaderoService(INumeroParqueaderoRepository _numeroparqueaderoRepository)
        {
            this.numeroparqueaderoRepository = _numeroparqueaderoRepository;
        }

        public Task<Result> DeleteNumeroParqueadero(NumeroParqueaderoDto entity)
        {
            return numeroparqueaderoRepository.DeleteNumeroParqueadero(entity);
        }

        public Task<Result> GetNumeroParqueaderoById(int Id)
        {
            return numeroparqueaderoRepository.GetNumeroParqueaderoById(Id);
        }

        public Task<Result> GetAllNumeroParqueaderos()
        {
            return numeroparqueaderoRepository.GetAllNumeroParqueaderos();
        }

        public Task<Result> InsertNumeroParqueadero(NumeroParqueaderoDto entity)
        {
            return numeroparqueaderoRepository.InsertNumeroParqueadero(entity);
        }

        public Task<Result> UpdateNumeroParqueadero(NumeroParqueaderoDto entity)
        {
            return numeroparqueaderoRepository.UpdateNumeroParqueadero(entity);
        }
    }
}

