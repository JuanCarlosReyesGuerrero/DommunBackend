using Commun;
using Commun.Logs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interface;

namespace DommunBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

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
                enviarLog.EnviarExcepcion(ex.Message, ex);
                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }

        /// <summary>
        /// Genera un correo con una clave temporal
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("RecuperarClave")]
        //public IActionResult RecuperarClave([FromBody] LoginModel loginModel)
        //{
        //    try
        //    {
        //        if (loginBackOfficeService.RecuperaPassword(loginModel))
        //            return Ok(true);
        //        else
        //            return BadRequest(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, ex.StackTrace);
        //        return BadRequest();
        //    }
        //}

        /// <summary>
        /// Actualiza la clave del usuario
        /// </summary>
        /// <param name="cambioClaveModel"></param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("CambiarClave")]
        //public IActionResult CambiarClave([FromBody] CambioPasswordModel cambioPasswordModel)
        //{
        //    try
        //    {
        //        var response = loginBackOfficeService.CambiarPassword(cambioPasswordModel);
        //        if (!response.Error)
        //        {
        //            return Ok(true);
        //        }
        //        else
        //        {
        //            return BadRequest(response);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, ex.StackTrace);
        //        return BadRequest();
        //    }
        //}
    }
}
