using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class DepartamentoService : IDepartamentoService
    {
        private IRepository<Departamento> departamentoRepository;

        public DepartamentoService(IRepository<Departamento> _departamentoRepository)
        {
            this.departamentoRepository = _departamentoRepository;
        }

        public void DeleteDepartamento(int id)
        {
            Departamento departamento = GetDepartamento(id);
            departamentoRepository.Remove(departamento);
            departamentoRepository.SaveChanges();
        }

        public IEnumerable<Departamento> GetAllDepartamentos()
        {
            return departamentoRepository.GetAll();
        }

        public Departamento GetDepartamento(int id)
        {
            return departamentoRepository.Get(id);
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