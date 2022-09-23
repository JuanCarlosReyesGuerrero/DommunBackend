using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.IRepository;
using ServicesLayer.ICustomServices;

namespace ServicesLayer.CustomServices
{
    public class AgenteService : IAgenteService
    {
        #region Property  
        private readonly IRepository<Agente> objRepository;
        private readonly IAgenteRepository agenteRepository;
        #endregion

        #region Constructor  
        public AgenteService(IRepository<Agente> _objRepository, IAgenteRepository _agenteRepository)
        {
            this.objRepository = _objRepository;
            this.agenteRepository = _agenteRepository;
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

        public Task<Result> ObtenerAgentes()
        {
            return agenteRepository.ObtenerAgentes();
        }

        public Task<Result> ObtenerAgenteById(int vId)
        {
            return agenteRepository.ObtenerAgenteById(vId);
        }
    }
}