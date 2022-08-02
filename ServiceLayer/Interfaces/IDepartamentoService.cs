﻿using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IDepartamentoService
    {
        IEnumerable<Departamento> GetAllDepartamentos();
        Departamento GetDepartamentoById(int? id);
        void InsertDepartamento(Departamento departamento);
        void UpdateDepartamento(Departamento departamento);
        void DeleteDepartamento(int? id);
    }
}
