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
    public class CaracteristicaController : ControllerBase
    {
        private readonly ICreateLogger _createLogger;
        private readonly ICaracteristicaService caracteristicaService;
        private readonly IMapper mapper;

        public CaracteristicaController(ICaracteristicaService _caracteristicaService, IMapper _mapper)
        {
            this.caracteristicaService = _caracteristicaService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllCaracteristicas
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCaracteristicas))]
        public Result GetAllCaracteristicas()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = caracteristicaService.GetAllCaracteristicas();

                var lstTemp = mapper.Map<List<CaracteristicaDto>>(queryTable.Result.Data);

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
        /// GetCaracteristica
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetCaracteristica))]
        public Result GetCaracteristica(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = caracteristicaService.GetCaracteristicaById(Id);

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
        /// InsertCaracteristica
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertCaracteristica))]
        public Result InsertCaracteristica(CaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = caracteristicaService.InsertCaracteristica(objModel);

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
        /// UpdateCaracteristica
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCaracteristica))]
        public Result UpdateCaracteristica(CaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = caracteristicaService.UpdateCaracteristica(objModel);

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
        /// DeleteCaracteristica
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteCaracteristica))]
        public Result DeleteCaracteristica(CaracteristicaDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = caracteristicaService.DeleteCaracteristica(objModel);

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
