using RepositoryLayer;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;
using System.Linq.Expressions;

namespace ServiceLayer.ClassServices
{
    public class UserService : IUserService
    {
        private IGenericRepository<ApplicationUser> userRepository;

        public UserService(IGenericRepository<ApplicationUser> _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public void Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> FindAll(Expression<Func<ApplicationUser, bool>> expression)
        {
            throw new NotImplementedException();

            //var domesticAccounts = _repository.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            //var owners = _repository.Owner.FindAll();
        }

        public IEnumerable<ApplicationUser> FindByEmail(string email)
        {
            return userRepository.Find(x => x.Email.Equals(email));            
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }        

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }        
    }
}
