using RepositoryLayer;
using System.Linq.Expressions;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        IEnumerable<ApplicationUser> FindAll(Expression<Func<ApplicationUser, bool>> expression);
        void Add(ApplicationUser entity);
        void AddRange(IEnumerable<ApplicationUser> entities);
        void Remove(ApplicationUser entity);
        void RemoveRange(IEnumerable<ApplicationUser> entities);

        IEnumerable<ApplicationUser> FindByEmail(string email);
    }
}
