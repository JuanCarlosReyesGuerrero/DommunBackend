using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IAgenteService
    {
        IEnumerable<Agente> GetAllAgentes();
        Agente GetAgenteById(int? id);
        void InsertAgente(Agente agente);
        void UpdateAgente(Agente agente);
        void DeleteAgente(int? id);
    }
}
