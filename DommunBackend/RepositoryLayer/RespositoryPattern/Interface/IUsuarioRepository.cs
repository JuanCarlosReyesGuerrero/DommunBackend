using DommunBackend.DomainLayer.Models;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.Interface
{
    public interface IUsuarioRepository<T> where T : ApplicationUser
    {
        IEnumerable<T> GetAll();

        T GetById(string? Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void SaveChanges();

        T GetByEmail(string vEmail);
    }
}
