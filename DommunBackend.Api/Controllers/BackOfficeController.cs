using Common;
using Common.Logs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IUserService userService;

        public BackOfficeController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [HttpPost]
        [Route("inicioSesion")]
        public async Task<IActionResult> InicioSesionAsync([FromBody] LoginModel loginModel)
        {
            Result oRespuesta = new Result();

            try
            {                
                var vRespuesta = await userService.GetUserIdentity(loginModel.Email, loginModel.Password);

                if (vRespuesta!=null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = vRespuesta;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constants.msjNoAutorizado;                  

                    return Ok(oRespuesta);
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);
                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }

        //RegistroAsync
    }
}
