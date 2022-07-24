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
            Municipio municipio = GetMunicipio(id);
            municipioRepository.Remove(municipio);
            municipioRepository.SaveChanges();
        }

        public IEnumerable<Municipio> GetAllMunicipios()
        {
            return municipioRepository.GetAll();
        }

        public Municipio GetMunicipio(int id)
        {
            return municipioRepository.Get(id);
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