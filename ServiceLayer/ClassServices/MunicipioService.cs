using DomainLayer.DTOs;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using RepositoryLayer.RespositoryPattern.Interface;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class MunicipioService : IMunicipioService
    {
        private IRepository<Municipio> municipioRepository;
        private IMunicipioRepository objRepository;

        public MunicipioService(IRepository<Municipio> _municipioRepository, IMunicipioRepository _objRepository)
        {
            this.municipioRepository = _municipioRepository;
            this.objRepository = _objRepository;
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

        public List<MunicipioDto> ObtenerMunicipioByDepartamento()
        {
            return objRepository.ObtenerMunicipioByDepartamento();
        }

        public void UpdateMunicipio(Municipio municipio)
        {
            municipioRepository.Update(municipio);
        }
    }
}