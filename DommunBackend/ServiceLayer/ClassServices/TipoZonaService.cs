using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class TipoZonaService : ITipoZonaService
    {
        private IRepository<TipoZona> tipoZonaRepository;

        public TipoZonaService(IRepository<TipoZona> _tipoZonaRepository)
        {
            this.tipoZonaRepository = _tipoZonaRepository;
        }

        public void DeleteTipoZona(int id)
        {
            TipoZona tipoZona = GetTipoZonaById(id);
            tipoZonaRepository.Remove(tipoZona);
            tipoZonaRepository.SaveChanges();
        }

        public IEnumerable<TipoZona> GetAllTipoZonas()
        {
            return tipoZonaRepository.GetAll();
        }

        public TipoZona GetTipoZonaById(int id)
        {
            return tipoZonaRepository.GetById(id);
        }

        public void InsertTipoZona(TipoZona tipoZona)
        {
            tipoZonaRepository.Insert(tipoZona);
        }

        public void UpdateTipoZona(TipoZona tipoZona)
        {
            tipoZonaRepository.Update(tipoZona);
        }
    }
}