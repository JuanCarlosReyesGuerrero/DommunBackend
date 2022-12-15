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
    public class TiempoConstruidoController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly ITiempoConstruidoService tiempoConstruidoService;
        private readonly IMapper mapper;

        public TiempoConstruidoController(ITiempoConstruidoService _tiempoConstruidoService, IMapper _mapper)
        {
            this.tiempoConstruidoService = _tiempoConstruidoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllTiempoConstruidos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTiempoConstruidos))]
        public Result GetAllTiempoConstruidos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = tiempoConstruidoService.GetAllTiempoConstruidos();

                var lstTemp = mapper.Map<List<TiempoConstruidoDto>>(queryTable.Result.Data);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = queryTable.Result.Success;
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
        /// GetTiempoConstruido
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetTiempoConstruido))]
        public Result GetTiempoConstruido(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = tiempoConstruidoService.GetTiempoConstruidoById(Id);

                if (objModel != null)
                {
                    oRespuesta.Success = objModel.Result.Success;
                    oRespuesta.Data = objModel.Result.Data;
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
        /// InsertTiempoConstruido
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertTiempoConstruido))]
        public Result InsertTiempoConstruido(TiempoConstruidoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = tiempoConstruidoService.InsertTiempoConstruido(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// UpdateTiempoConstruido
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTiempoConstruido))]
        public Result UpdateTiempoConstruido(TiempoConstruidoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = tiempoConstruidoService.UpdateTiempoConstruido(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// DeleteTiempoConstruido
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTiempoConstruido))]
        public Result DeleteTiempoConstruido(TiempoConstruidoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = tiempoConstruidoService.DeleteTiempoConstruido(objModel);

                oRespuesta.Success = vRespuesta.Result.Success;
                oRespuesta.Message = vRespuesta.Result.Message;

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
