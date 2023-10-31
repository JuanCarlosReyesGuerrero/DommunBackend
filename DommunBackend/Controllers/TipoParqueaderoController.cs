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
    public class TipoParqueaderoController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly ITipoParqueaderoService tipoParqueaderoService;
        private readonly IMapper mapper;

        public TipoParqueaderoController(ITipoParqueaderoService _tipoParqueaderoService, IMapper _mapper)
        {
            this.tipoParqueaderoService = _tipoParqueaderoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllTipoParqueaderos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTipoParqueaderos))]
        public Result GetAllTipoParqueaderos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = tipoParqueaderoService.GetAllTipoParqueaderos();

                var lstTemp = mapper.Map<List<TipoParqueaderoDto>>(queryTable.Result.Data);

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
        /// GetTipoParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetTipoParqueadero))]
        public Result GetTipoParqueadero(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = tipoParqueaderoService.GetTipoParqueaderoById(Id);

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
        /// InsertTipoParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertTipoParqueadero))]
        public Result InsertTipoParqueadero(TipoParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = tipoParqueaderoService.InsertTipoParqueadero(objModel);

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
        /// UpdateTipoParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTipoParqueadero))]
        public Result UpdateTipoParqueadero(TipoParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = tipoParqueaderoService.UpdateTipoParqueadero(objModel);

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
        /// DeleteTipoParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTipoParqueadero))]
        public Result DeleteTipoParqueadero(TipoParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = tipoParqueaderoService.DeleteTipoParqueadero(objModel);

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
