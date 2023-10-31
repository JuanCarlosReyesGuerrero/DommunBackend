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
    public class NumeroParqueaderoController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly INumeroParqueaderoService numeroParqueaderoService;
        private readonly IMapper mapper;

        public NumeroParqueaderoController(INumeroParqueaderoService _numeroParqueaderoService, IMapper _mapper)
        {
            this.numeroParqueaderoService = _numeroParqueaderoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllNumeroParqueaderos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllNumeroParqueaderos))]
        public Result GetAllNumeroParqueaderos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = numeroParqueaderoService.GetAllNumeroParqueaderos();

                var lstTemp = mapper.Map<List<NumeroParqueaderoDto>>(queryTable.Result.Data);

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
        /// GetNumeroParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetNumeroParqueadero))]
        public Result GetNumeroParqueadero(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = numeroParqueaderoService.GetNumeroParqueaderoById(Id);

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
        /// InsertNumeroParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertNumeroParqueadero))]
        public Result InsertNumeroParqueadero(NumeroParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = numeroParqueaderoService.InsertNumeroParqueadero(objModel);

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
        /// UpdateNumeroParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateNumeroParqueadero))]
        public Result UpdateNumeroParqueadero(NumeroParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = numeroParqueaderoService.UpdateNumeroParqueadero(objModel);

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
        /// DeleteNumeroParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteNumeroParqueadero))]
        public Result DeleteNumeroParqueadero(NumeroParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = numeroParqueaderoService.DeleteNumeroParqueadero(objModel);

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
