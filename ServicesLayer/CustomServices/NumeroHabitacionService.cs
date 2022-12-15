using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class NumeroHabitacionService : INumeroHabitacionService
    {
        private readonly INumeroHabitacionRepository numerohabitacioneRepository;

        public NumeroHabitacionService(INumeroHabitacionRepository _numerohabitacioneRepository)
        {
            this.numerohabitacioneRepository = _numerohabitacioneRepository;
        }

        public Task<Result> DeleteNumeroHabitacion(NumeroHabitacionDto entity)
        {
            return numerohabitacioneRepository.DeleteNumeroHabitacion(entity);
        }

        public Task<Result> GetNumeroHabitacionById(int Id)
        {
            return numerohabitacioneRepository.GetNumeroHabitacionById(Id);
        }

        public Task<Result> GetAllNumeroHabitaciones()
        {
            return numerohabitacioneRepository.GetAllNumeroHabitaciones();
        }

        public Task<Result> InsertNumeroHabitacion(NumeroHabitacionDto entity)
        {
            return numerohabitacioneRepository.InsertNumeroHabitacion(entity);
        }

        public Task<Result> UpdateNumeroHabitacion(NumeroHabitacionDto entity)
        {
            return numerohabitacioneRepository.UpdateNumeroHabitacion(entity);
        }
    }
}

