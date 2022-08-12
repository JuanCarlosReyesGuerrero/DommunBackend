using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;
using ServicesLayer.Interface;

namespace ServicesLayer.Service
{
    public class AgenteService : IAgenteService
    {
        #region Property  
        private readonly IRepository<Agente> objRepository;
        #endregion

        #region Constructor  
        public AgenteService(IRepository<Agente> _objRepository)
        {
            this.objRepository = _objRepository;
        }
        #endregion

        public void DeleteAgente(int id)
        {
            Agente customer = GetAgenteById(id);
            objRepository.Remove(customer);
            objRepository.SaveChanges();
        }

        public Agente GetAgenteById(int id)
        {
            return objRepository.Get(id);
        }

        public IEnumerable<Agente> GetAllAgentes()
        {
            return objRepository.GetAll();
        }

        public void InsertAgente(Agente model)
        {
            objRepository.Insert(model);
        }

        public void UpdateAgente(Agente model)
        {
            objRepository.Update(model);
        }
    }
}