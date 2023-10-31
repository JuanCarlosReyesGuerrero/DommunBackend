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
    public class EstratoController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly IEstratoService estratoService;
        private readonly IMapper mapper;

        public EstratoController(IEstratoService _estratoService, IMapper _mapper)
        {
            this.estratoService = _estratoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllEstratos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllEstratos))]
        public Result GetAllEstratos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = estratoService.GetAllEstratos();

                var lstTemp = mapper.Map<List<EstratoDto>>(queryTable.Result.Data);

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
        /// GetEstrato
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetEstrato))]
        public Result GetEstrato(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = estratoService.GetEstratoById(Id);

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
        /// InsertEstrato
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertEstrato))]
        public Result InsertEstrato(EstratoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = estratoService.InsertEstrato(objModel);

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
        /// UpdateEstrato
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateEstrato))]
        public Result UpdateEstrato(EstratoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = estratoService.UpdateEstrato(objModel);

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
        /// DeleteEstrato
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteEstrato))]
        public Result DeleteEstrato(EstratoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = estratoService.DeleteEstrato(objModel);

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
