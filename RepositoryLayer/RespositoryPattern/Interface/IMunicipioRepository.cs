using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern.Interface
{
    public interface IMunicipioRepository : IDisposable
    {
        IEnumerable<Municipio> GetAll();
        Municipio GetByID(int Id);
        void Insert(Municipio entity);
        void Delete(int Id);
        void Update(Municipio entity);
        void Save();
    }
}
