using DommunBackend.Common;
using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class UserService : IUserService
    {
        private IGenericRepository<ApplicationUser> userRepository;

        public UserService(IGenericRepository<ApplicationUser> _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public IEnumerable<ApplicationUser> FindByEmail(string email)
        {
            return userRepository.Find(x => x.Email.Equals(email));
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
    }
}
