using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;

namespace RepositoryLayer.RespositoryPattern.Repository
{
    public class BackOfficeRepository : IBackOfficeRepository
    {
        private readonly ApplicationDbContext objContext;

        EnviarLog enviarLog = new EnviarLog();

        public BackOfficeRepository(ApplicationDbContext _objContext)
        {
            this.objContext = _objContext;
        }

        public async Task<Result> ValidarLogin(LoginModel loginModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var result = (from us in objContext.Users
                              join ur in objContext.UserRoles on us.Id equals ur.UserId
                              join rol in objContext.Roles on ur.RoleId equals rol.Id
                              select us)
                            .Where(us => us.Email == loginModel.Email)
                            .FirstOrDefault();

                if (result != null)
                {
                    PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

                    var vValida = passwordHasher.VerifyHashedPassword(result, result.PasswordHash, loginModel.Password);

                    if (vValida.ToString() == "Success")
                    {
                        UsuarioLoginDto model = new UsuarioLoginDto();
                        {
                            model.UserName = result.UserName;
                            model.Email = result.Email;
                            //model.Rol = result.ro
                        };

                        oRespuesta.Success = true;
                        oRespuesta.Data = model;
                    }
                    else
                    {
                        oRespuesta.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }
    }
}
