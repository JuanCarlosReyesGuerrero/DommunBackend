using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class ZonaService : IZonaService
    {
        private IRepository<Zona> zonaRepository;

        public ZonaService(IRepository<Zona> _zonaRepository)
        {
            this.zonaRepository = _zonaRepository;
        }

        public void DeleteZona(int id)
        {
            Zona zona = GetZonaById(id);
            zonaRepository.Remove(zona);
            zonaRepository.SaveChanges();
        }

        public IEnumerable<Zona> GetAllZonas()
        {
            return zonaRepository.GetAll();
        }

        public Zona GetZonaById(int id)
        {
            return zonaRepository.GetById(id);
        }

        public void InsertZona(Zona zona)
        {
            zonaRepository.Insert(zona);
        }

        public void UpdateZona(Zona zona)
        {
            zonaRepository.Update(zona);
        }
    }
}