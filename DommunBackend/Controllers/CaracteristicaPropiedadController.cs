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
    public class CaracteristicaPropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly ICaracteristicaPropiedadService caracteristicaPropiedadService;
        private readonly IMapper mapper;

        public CaracteristicaPropiedadController(ICaracteristicaPropiedadService _caracteristicaPropiedadService, IMapper _mapper)
        {
            this.caracteristicaPropiedadService = _caracteristicaPropiedadService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllCaracteristicaPropiedads
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCaracteristicaPropiedads))]
        public Result GetAllCaracteristicaPropiedads()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = caracteristicaPropiedadService.GetAllCaracteristicaPropiedades();

                var lstTemp = mapper.Map<List<CaracteristicaPropiedadDto>>(queryTable.Result.Data);

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
        /// GetCaracteristicaPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetCaracteristicaPropiedad))]
        public Result GetCaracteristicaPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = caracteristicaPropiedadService.GetCaracteristicaPropiedadById(Id);

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
        /// InsertCaracteristicaPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertCaracteristicaPropiedad))]
        public Result InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = caracteristicaPropiedadService.InsertCaracteristicaPropiedad(objModel);

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
        /// UpdateCaracteristicaPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCaracteristicaPropiedad))]
        public Result UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = caracteristicaPropiedadService.UpdateCaracteristicaPropiedad(objModel);

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
        /// DeleteCaracteristicaPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteCaracteristicaPropiedad))]
        public Result DeleteCaracteristicaPropiedad(CaracteristicaPropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = caracteristicaPropiedadService.DeleteCaracteristicaPropiedad(objModel);

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
