using AutoMapper;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ICustomServices;

namespace DommunBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCaracteristicaController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly ITipoCaracteristicaService tipoCaracteristicaService;
        private readonly IMapper mapper;

        public TipoCaracteristicaController(ITipoCaracteristicaService _tipoCaracteristicaService, IMapper _mapper)
        {
            this.tipoCaracteristicaService = _tipoCaracteristicaService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllTipoCaracteristicas
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTipoCaracteristicas))]
        public Result GetAllTipoCaracteristicas()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = tipoCaracteristicaService.GetAllTipoCaracteristicas();

                var lstTemp = mapper.Map<List<TipoCaracteristicaDto>>(queryTable.Result.Data);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = queryTable.Result.Success;
                    oRespuesta.Data = lstTemp;
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
        /// GetTipoCaracteristica
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetTipoCaracteristica))]
        public Result GetTipoCaracteristica(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = tipoCaracteristicaService.GetTipoCaracteristicaById(Id);

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
        /// InsertTipoCaracteristica
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertTipoCaracteristica))]
        public Result InsertTipoCaracteristica(TipoCaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = tipoCaracteristicaService.InsertTipoCaracteristica(objModel);

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
        /// UpdateTipoCaracteristica
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTipoCaracteristica))]
        public Result UpdateTipoCaracteristica(TipoCaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = tipoCaracteristicaService.UpdateTipoCaracteristica(objModel);

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
        /// DeleteTipoCaracteristica
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTipoCaracteristica))]
        public Result DeleteTipoCaracteristica(TipoCaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = tipoCaracteristicaService.DeleteTipoCaracteristica(objModel);

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
    }
}
