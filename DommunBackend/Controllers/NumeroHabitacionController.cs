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
    public class NumeroHabitacionController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly INumeroHabitacionService numeroHabitacionService;
        private readonly IMapper mapper;

        public NumeroHabitacionController(INumeroHabitacionService _numeroHabitacionService, IMapper _mapper)
        {
            this.numeroHabitacionService = _numeroHabitacionService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllNumeroHabitacions
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllNumeroHabitacions))]
        public Result GetAllNumeroHabitacions()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = numeroHabitacionService.GetAllNumeroHabitaciones();

                var lstTemp = mapper.Map<List<NumeroHabitacionDto>>(queryTable.Result.Data);

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
        /// GetNumeroHabitacion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetNumeroHabitacion))]
        public Result GetNumeroHabitacion(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = numeroHabitacionService.GetNumeroHabitacionById(Id);

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
        /// InsertNumeroHabitacion
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertNumeroHabitacion))]
        public Result InsertNumeroHabitacion(NumeroHabitacionDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = numeroHabitacionService.InsertNumeroHabitacion(objModel);

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
        /// UpdateNumeroHabitacion
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateNumeroHabitacion))]
        public Result UpdateNumeroHabitacion(NumeroHabitacionDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = numeroHabitacionService.UpdateNumeroHabitacion(objModel);

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
        /// DeleteNumeroHabitacion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteNumeroHabitacion))]
        public Result DeleteNumeroHabitacion(NumeroHabitacionDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = numeroHabitacionService.DeleteNumeroHabitacion(objModel);

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
