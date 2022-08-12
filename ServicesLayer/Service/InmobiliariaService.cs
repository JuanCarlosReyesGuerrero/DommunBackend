using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class InmobiliariaService : IInmobiliariaService
    {
        #region Property  
        private readonly IRepository<Inmobiliaria> objRepository;
        #endregion

        #region Constructor  
        public InmobiliariaService(IRepository<Inmobiliaria> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteInmobiliaria(int id)
        {
            Inmobiliaria customer = GetInmobiliariaById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Inmobiliaria GetInmobiliariaById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Inmobiliaria> GetAllInmobiliarias()
        {
            return objRepository.GetAll();
        }

        public void InsertInmobiliaria(Inmobiliaria model)
        {
            objRepository.Insert(model);
        }

        public void UpdateInmobiliaria(Inmobiliaria model)
        {
            objRepository.Update(model);
        }
    }
}