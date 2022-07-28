using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.RespositoryPattern
{
    public class UsuarioRepository<T> : IUsuarioRepository<T> where T : UserInfo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;

        public UsuarioRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public T GetById(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetByEmail(string vEmail)
        {
            return entities.SingleOrDefault(c => c.Email == vEmail);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
