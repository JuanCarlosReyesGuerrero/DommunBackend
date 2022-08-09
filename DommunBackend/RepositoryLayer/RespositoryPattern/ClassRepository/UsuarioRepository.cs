using DommunBackend.Data;
using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using Microsoft.EntityFrameworkCore;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.ClassRepository
{
    public class UsuarioRepository<T> : IUsuarioRepository<T> where T : ApplicationUser
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

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetByEmail(string vEmail)
        {
            return entities.SingleOrDefault(c => c.Email == vEmail);
        }

        public T GetById(string? Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
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
