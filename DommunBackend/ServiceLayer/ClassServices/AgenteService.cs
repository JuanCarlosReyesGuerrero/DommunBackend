using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class AgenteService : IAgenteService
    {
        private IRepository<Agente> agenteRepository;

        public AgenteService(IRepository<Agente> _agenteRepository)
        {
            this.agenteRepository = _agenteRepository;
        }

        public void DeleteAgente(int? id)
        {
            Agente agente = GetAgenteById(id);
            agenteRepository.Remove(agente);
            agenteRepository.SaveChanges();
        }

        public IEnumerable<Agente> GetAllAgentes()
        {
            return agenteRepository.GetAll();
        }

        public Agente GetAgenteById(int? id)
        {
            return agenteRepository.GetById(id);
        }

        public void InsertAgente(Agente agente)
        {
            agenteRepository.Insert(agente);
        }

        public void UpdateAgente(Agente agente)
        {
            agenteRepository.Update(agente);
        }
    }
}