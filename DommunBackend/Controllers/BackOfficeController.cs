using Commun;
using Commun.Logs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ICustomServices;

namespace DommunBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly IBackOfficeService objService;

        public BackOfficeController(IBackOfficeService _objService)
        {
            this.objService = _objService;
        }

        [HttpPost]
        [Route("InicioSesion")]
        public async Task<IActionResult> InicioSesionAsync([FromBody] LoginModel loginModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await objService.ValidarLogin(loginModel);

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Message = Constantes.msjLoginCorrecto;
                    oRespuesta.Data = vRespuesta.Data;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjLoginErrado;

                    return Ok(oRespuesta);
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> RegistrarAsync([FromBody] LoginModel loginModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await objService.Registro(loginModel);

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Message = vRespuesta.Message;
                    oRespuesta.Data = vRespuesta.Data;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = vRespuesta.Message;

                    return Ok(oRespuesta);
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CambioPassword")]
        public async Task<IActionResult> CambioPasswordAsync([FromBody] ChangePasswordModel loginModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await objService.CambioPassword(loginModel);

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Message = vRespuesta.Message;
                    oRespuesta.Data = vRespuesta.Data;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = vRespuesta.Message;

                    return Ok(oRespuesta);
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }
    }
}
