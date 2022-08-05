using Common;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ApplicationUser> GetUserIdentity(string email, string password)
        {
            string vPass = password + email + Constants.pivotePass;            

            ApplicationUser objTemp = new ApplicationUser();
            List<ApplicationUser> objList = new List<ApplicationUser>();

            try
            {
                ApplicationUser authUser = new ApplicationUser();

                bool vTemp = false;

                var hasher = new PasswordHasher<ApplicationUser>();
                var hash = hasher.HashPassword(authUser, vPass);

                objList = FindByEmail(email).ToList();

                objTemp = objList.SingleOrDefault(s => s.Email == email);

                if (objTemp != null)
                {
                    if (objTemp.Email != null && objTemp.PasswordHash != null)
                    {
                        var verified = hasher.VerifyHashedPassword(authUser, objTemp.PasswordHash, vPass);

                        if (verified.ToString() == "Success")
                            vTemp = true;
                        else
                            objTemp = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTemp;
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
