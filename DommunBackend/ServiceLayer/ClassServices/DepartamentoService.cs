using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class DepartamentoService : IDepartamentoService
    {
        private IRepository<Departamento> departamentoRepository;

        public DepartamentoService(IRepository<Departamento> _departamentoRepository)
        {
            this.departamentoRepository = _departamentoRepository;
        }

        public void DeleteDepartamento(int? id)
        {
            Departamento departamento = GetDepartamentoById(id);
            departamentoRepository.Remove(departamento);
            departamentoRepository.SaveChanges();
        }

        public IEnumerable<Departamento> GetAllDepartamentos()
        {
            return departamentoRepository.GetAll();
        }

        public Departamento GetDepartamentoById(int? id)
        {
            return departamentoRepository.GetById(id);
        }

        public void InsertDepartamento(Departamento departamento)
        {
            departamentoRepository.Insert(departamento);
        }

        public void UpdateDepartamento(Departamento departamento)
        {
            departamentoRepository.Update(departamento);
        }
    }
}