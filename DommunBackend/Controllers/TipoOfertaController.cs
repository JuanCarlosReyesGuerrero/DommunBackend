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
    public class TipoOfertaController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly ITipoOfertaService tipoOfertaService;
        private readonly IMapper mapper;

        public TipoOfertaController(ITipoOfertaService _tipoOfertaService, IMapper _mapper)
        {
            this.tipoOfertaService = _tipoOfertaService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllTipoOfertas
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTipoOfertas))]
        public Result GetAllTipoOfertas()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = tipoOfertaService.GetAllTipoOfertas();

                var lstTemp = mapper.Map<List<TipoOfertaDto>>(queryTable.Result.Data);

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
        /// GetTipoOferta
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetTipoOferta))]
        public Result GetTipoOferta(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = tipoOfertaService.GetTipoOfertaById(Id);

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
        /// InsertTipoOferta
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertTipoOferta))]
        public Result InsertTipoOferta(TipoOfertaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = tipoOfertaService.InsertTipoOferta(objModel);

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
        /// UpdateTipoOferta
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTipoOferta))]
        public Result UpdateTipoOferta(TipoOfertaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = tipoOfertaService.UpdateTipoOferta(objModel);

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
        /// DeleteTipoOferta
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTipoOferta))]
        public Result DeleteTipoOferta(TipoOfertaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = tipoOfertaService.DeleteTipoOferta(objModel);

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
