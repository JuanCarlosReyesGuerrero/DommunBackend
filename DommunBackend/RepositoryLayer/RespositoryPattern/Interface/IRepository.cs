using DommunBackend.DomainLayer.Models;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int? Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void SaveChanges();
    }
}
