using DomainLayer.Models;

namespace ServicesLayer.Interface
{
    public interface IAgenteService
    {
        IEnumerable<Agente> GetAllAgentes();
        Agente GetAgenteById(int id);
        void InsertAgente(Agente model);
        void UpdateAgente(Agente model);
        void DeleteAgente(int id);
    }
}
