﻿using DomainLayer.Dtos;
using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
{
    public interface IAgenteService
    {
        Task<Result> GetAllAgentes();
        Task<Result> GetAgenteById(int Id);
        Task<Result> InsertAgente(AgenteDto entity);
        Task<Result> UpdateAgente(AgenteDto entity);
        Task<Result> DeleteAgente(AgenteDto entity);
                     
        Task<Result> ObtenerAgentesFull();
        Task<Result> ObtenerAgenteFullById(int vId);
    }
}