using Commun;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;

namespace RepositoryLayer.RespositoryPattern.Repository
{
    public class BackOfficeRepository : IBackOfficeRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        EnviarLog enviarLog = new EnviarLog();

        public BackOfficeRepository(
            ApplicationDbContext _objContext,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IConfiguration _configuration)
        {
            this.objContext = _objContext;
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this.configuration = _configuration;
        }

        public async Task<Result> ValidarLogin(LoginModel objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var result = (from us in objContext.Users
                              join ur in objContext.UserRoles on us.Id equals ur.UserId
                              join rol in objContext.Roles on ur.RoleId equals rol.Id
                              select us)
                            .Where(us => us.Email == objModel.Email)
                            .FirstOrDefault();

                if (result != null)
                {
                    PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

                    var vValida = passwordHasher.VerifyHashedPassword(result, result.PasswordHash, objModel.Password);

                    if (vValida.ToString() == "Success")
                    {
                        UsuarioLoginDto model = new UsuarioLoginDto();
                        {
                            model.UserName = result.UserName;
                            model.Email = result.Email;
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

        public async Task<Result> Registro(LoginModel objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var userExists = await userManager.FindByEmailAsync(objModel.Email);

                if (userExists != null)
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjUsuarioEstaRegistrado;
                }
                else
                {
                    ApplicationUser user = new()
                    {
                        Email = objModel.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = objModel.UserName,
                    };

                    var result = await userManager.CreateAsync(user, objModel.Password);

                    if (!result.Succeeded)
                    {
                        oRespuesta.Success = false;
                        oRespuesta.Message = Constantes.msjUsuarioNoGuardado;
                    }
                    else
                    {
                        oRespuesta.Success = true;
                        oRespuesta.Message = Constantes.msjUsuarioGuardado;
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

        public async Task<Result> CambioPassword(ChangePasswordModel objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var user = await userManager.FindByEmailAsync(objModel.Email);

                if (user == null)
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
                else if (string.Compare(objModel.NewPassword, objModel.ConfirmNewpassword) != 0)
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjDosPasseordNoIguales;
                }
                else
                {
                    var result = await userManager.ChangePasswordAsync(user, objModel.CurrentPassword, objModel.NewPassword);

                    if (!result.Succeeded)
                    {
                        oRespuesta.Success = false;
                        oRespuesta.Message = Constantes.msjNoSepUdoCambiarPass;
                    }
                    else
                    {
                        oRespuesta.Success = true;
                        oRespuesta.Message = Constantes.msjPassCambiado;
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

        public async Task<Result> RegistroAdmin(LoginModel objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var userExists = await userManager.FindByEmailAsync(objModel.Email);

                if (userExists != null)
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjUsuarioEstaRegistrado;
                }
                else
                {
                    ApplicationUser user = new()
                    {
                        Email = objModel.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = objModel.UserName,
                    };

                    var result = await userManager.CreateAsync(user, objModel.Password);

                    if (!result.Succeeded)
                    {
                        oRespuesta.Success = false;
                        oRespuesta.Message = Constantes.msjUsuarioNoGuardado;
                    }
                    else
                    {
                        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                        if (!await roleManager.RoleExistsAsync(UserRoles.User))
                            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                            await userManager.AddToRoleAsync(user, UserRoles.Admin);

                        oRespuesta.Success = true;
                        oRespuesta.Message = Constantes.msjUsuarioGuardado;
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

//https://www.youtube.com/watch?v=_H5X8-YvWG0&t=1351s