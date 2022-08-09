using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class PlanMembresiaService : IPlanMembresiaService
    {
        private IRepository<PlanMembresia> objRepository;

        public PlanMembresiaService(IRepository<PlanMembresia> _objRepository)
        {
            this.objRepository = _objRepository;
        }

        public void DeletePlanMembresia(int? id)
        {
            PlanMembresia objModel = GetPlanMembresiaById(id);
            objRepository.Remove(objModel);
            objRepository.SaveChanges();
        }

        public IEnumerable<PlanMembresia> GetAllPlanMembresias()
        {
            return objRepository.GetAll();
        }

        public PlanMembresia GetPlanMembresiaById(int? id)
        {
            return objRepository.GetById(id);
        }

        public void InsertPlanMembresia(PlanMembresia objModel)
        {
            objRepository.Insert(objModel);
        }

        public void UpdatePlanMembresia(PlanMembresia objModel)
        {
            objRepository.Update(objModel);
        }
    }
}
