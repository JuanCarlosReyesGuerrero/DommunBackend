using AutoMapper;
using Commun.Logs;
using Commun.Utilidades;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ICustomServices;

namespace DommunBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgenteController : ControllerBase
    {
        private readonly IAgenteService _agenteService;
        private readonly IMapper _mapper;
        private readonly ICreateLogger _createLogger;
        private readonly IAlmacenamientoAzureStorage _almacenamientoAzureStorage;

        public AgenteController(IAgenteService agenteService,
            IMapper mapper,
            ICreateLogger createLogger,
            IAlmacenamientoAzureStorage almacenamientoAzureStorage)
        {
            _agenteService = agenteService;
            _mapper = mapper;
            _createLogger = createLogger;
            _almacenamientoAzureStorage = almacenamientoAzureStorage;
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
                var queryTable = _agenteService.GetAllAgentes();

                var lstTemp = _mapper.Map<List<AgenteDto>>(queryTable.Result.Data);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = queryTable.Result.Success;
                    oRespuesta.Data = lstTemp;
                    oRespuesta.Message = queryTable.Result.Message;
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

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
                var objModel = _agenteService.GetAgenteById(Id);

                if (objModel != null)
                {
                    oRespuesta.Success = objModel.Result.Success;
                    oRespuesta.Data = objModel.Result.Data;
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

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
        public async Task<Result> InsertAgente([FromForm] AgenteCreacionDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                //if (objModel.FotoPerfil != null)
                //{
                //    objModel.FotoPerfil = await _almacenamientoAzureStorage.GuardarArchivo(contenedor, objModel.FotoPerfil);
                //}

                var vRespuesta = _agenteService.InsertAgente(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

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
        public Result UpdateAgente(AgenteDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = _agenteService.UpdateAgente(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

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
        public Result DeleteAgente(AgenteDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = _agenteService.DeleteAgente(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

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
                var vRespuesta = await _agenteService.ObtenerAgentesFull();

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = vRespuesta.Success;
                    oRespuesta.Message = vRespuesta.Message;
                    oRespuesta.Data = vRespuesta.Data;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = vRespuesta.Success;
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

        [HttpGet(nameof(GetAgenteById))]
        public async Task<Result> GetAgenteById(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await _agenteService.ObtenerAgenteFullById(Id);

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = vRespuesta.Success;
                    oRespuesta.Message = vRespuesta.Message;
                    oRespuesta.Data = vRespuesta.Data;

                    return oRespuesta;
                }
                else
                {
                    oRespuesta.Success = vRespuesta.Success;
                    oRespuesta.Message = vRespuesta.Message;

                    return oRespuesta;
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;

                return oRespuesta;
            }
        }
    }
}
