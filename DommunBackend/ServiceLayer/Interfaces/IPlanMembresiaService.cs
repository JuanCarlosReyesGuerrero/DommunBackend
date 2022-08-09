using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IPlanMembresiaService
    {
        IEnumerable<PlanMembresia> GetAllPlanMembresias();
        PlanMembresia GetPlanMembresiaById(int? id);
        void InsertPlanMembresia(PlanMembresia entity);
        void UpdatePlanMembresia(PlanMembresia entity);
        void DeletePlanMembresia(int? id);
    }
}
