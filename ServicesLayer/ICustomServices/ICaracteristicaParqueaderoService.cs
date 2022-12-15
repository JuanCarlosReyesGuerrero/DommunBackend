using DomainLayer.Dtos;
 using DomainLayer.Models;
 namespace ServicesLayer.ICustomServices
 
 {
 public interface ICaracteristicaParqueaderoService
 {
 Task<Result> GetAllCaracteristicaParqueaderos();
 Task<Result> GetCaracteristicaParqueaderoById(int Id);
 Task<Result> InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
 Task<Result> UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
 Task<Result> DeleteCaracteristicaParqueadero(CaracteristicaParqueaderoDto entity);
 }
 }
 
