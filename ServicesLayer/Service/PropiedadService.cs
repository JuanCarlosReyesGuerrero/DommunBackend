﻿using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class PropiedadService : IPropiedadService
    {
        #region Property  
        private readonly IRepository<Propiedad> objRepository;
        #endregion

        #region Constructor  
        public PropiedadService(IRepository<Propiedad> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeletePropiedad(int id)
        {
            Propiedad customer = GetPropiedadById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Propiedad GetPropiedadById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Propiedad> GetAllPropiedades()
        {
            return objRepository.GetAll();
        }

        public void InsertPropiedad(Propiedad model)
        {
            objRepository.Insert(model);
        }

        public void UpdatePropiedad(Propiedad model)
        {
            objRepository.Update(model);
        }
    }
}