using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface INumeroHabitacionService
    {
        Task<Result> GetAllNumeroHabitaciones();
        Task<Result> GetNumeroHabitacionById(int Id);
        Task<Result> InsertNumeroHabitacion(NumeroHabitacionDto entity);
        Task<Result> UpdateNumeroHabitacion(NumeroHabitacionDto entity);
        Task<Result> DeleteNumeroHabitacion(NumeroHabitacionDto entity);
    }
}

