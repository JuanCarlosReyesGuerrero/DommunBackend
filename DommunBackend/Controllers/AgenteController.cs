using AutoMapper;
using Commun;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicesLayer.CustomServices;
using ServicesLayer.ICustomServices;

namespace DommunBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgenteController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IAgenteService agenteService;
        private readonly IMapper mapper;

        public AgenteController(IAgenteService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllAgentes
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllAgentes))]
        public Result GetAllAgentes()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllAgentes();
                var objModel = queryTable.OrderBy(x => x.Nombres).ToList();

                var lstTemp = mapper.Map<List<AgenteDto>>(objModel);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// GetAgente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAgente))]
        public Result GetAgente(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetAgenteById(Id);

                var lstTemp = mapper.Map<AgenteDto>(objModel);

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// InsertAgente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertAgente))]
        public Result InsertAgente(Agente objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertAgente(objModel);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Guardado";

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// UpdateAgente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateAgente))]
        public Result UpdateAgente(Agente objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateAgente(objModel);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Actualizado";

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// DeleteAgente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteAgente))]
        public Result DeleteAgente(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteAgente(Id);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Eliminado";

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        [HttpGet(nameof(GetAgentesFull))]
        public async Task<IActionResult> GetAgentesFull()
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await agenteService.ObtenerAgentes();

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

        [HttpGet(nameof(GetAgenteById))]
        public async Task<Result> GetAgenteById(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await agenteService.ObtenerAgenteById(Id);                         

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Message = vRespuesta.Message;
                    oRespuesta.Data = vRespuesta.Data;

                    return oRespuesta;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = vRespuesta.Message;

                    return oRespuesta;
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;

                return oRespuesta;
            }
        }
    }
}
