using DomainLayer.Models;

namespace ServicesLayer.ICustomServices
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
