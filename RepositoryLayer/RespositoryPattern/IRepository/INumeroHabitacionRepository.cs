using DomainLayer.Dtos;
using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.IRepository
{
    public interface INumeroHabitacionRepository
    {
        Task<Result> GetAllNumeroHabitaciones();
        Task<Result> GetNumeroHabitacionById(int Id);
        Task<Result> InsertNumeroHabitacion(NumeroHabitacionDto entity);
        Task<Result> UpdateNumeroHabitacion(NumeroHabitacionDto entity);
        Task<Result> DeleteNumeroHabitacion(NumeroHabitacionDto entity);
    }
}

