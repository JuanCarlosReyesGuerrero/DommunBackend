using DomainLayer.Models;

namespace RepositoryLayer.RespositoryPattern
{
    public interface IUsuarioRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void SaveChanges();

        T GetByEmail(string vEmail);
    }
}
