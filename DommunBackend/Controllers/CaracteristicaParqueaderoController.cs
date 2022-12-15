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
    public class CaracteristicaParqueaderoController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly ICaracteristicaParqueaderoService caracteristicaParqueaderoService;
        private readonly IMapper mapper;

        public CaracteristicaParqueaderoController(ICaracteristicaParqueaderoService _caracteristicaParqueaderoService, IMapper _mapper)
        {
            this.caracteristicaParqueaderoService = _caracteristicaParqueaderoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllCaracteristicaParqueaderos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCaracteristicaParqueaderos))]
        public Result GetAllCaracteristicaParqueaderos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = caracteristicaParqueaderoService.GetAllCaracteristicaParqueaderos();

                var lstTemp = mapper.Map<List<CaracteristicaParqueaderoDto>>(queryTable.Result.Data);

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
        /// GetCaracteristicaParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetCaracteristicaParqueadero))]
        public Result GetCaracteristicaParqueadero(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = caracteristicaParqueaderoService.GetCaracteristicaParqueaderoById(Id);

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
        /// InsertCaracteristicaParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertCaracteristicaParqueadero))]
        public Result InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = caracteristicaParqueaderoService.InsertCaracteristicaParqueadero(objModel);

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
        /// UpdateCaracteristicaParqueadero
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCaracteristicaParqueadero))]
        public Result UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = caracteristicaParqueaderoService.UpdateCaracteristicaParqueadero(objModel);

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
        /// DeleteCaracteristicaParqueadero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteCaracteristicaParqueadero))]
        public Result DeleteCaracteristicaParqueadero(CaracteristicaParqueaderoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = caracteristicaParqueaderoService.DeleteCaracteristicaParqueadero(objModel);

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
