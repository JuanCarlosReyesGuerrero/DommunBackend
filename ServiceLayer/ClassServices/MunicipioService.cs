using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class MunicipioService : IMunicipioService
    {
        private IRepository<Municipio> municipioRepository;

        public MunicipioService(IRepository<Municipio> _municipioRepository)
        {
            this.municipioRepository = _municipioRepository;
        }

        public void DeleteMunicipio(int id)
        {
            Municipio municipio = GetMunicipioById(id);
            municipioRepository.Remove(municipio);
            municipioRepository.SaveChanges();
        }

        public IEnumerable<Municipio> GetAllMunicipios()
        {
            return municipioRepository.GetAll();
        }

        public Municipio GetMunicipioById(int id)
        {
            return municipioRepository.GetById(id);
        }

        public void InsertMunicipio(Municipio municipio)
        {
            municipioRepository.Insert(municipio);
        }

        public void UpdateMunicipio(Municipio municipio)
        {
            municipioRepository.Update(municipio);
        }
    }
}