using AutoMapper;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interface;

namespace DommunBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly ITipoPropiedadService objService;
        private readonly IMapper mapper;

        public TipoPropiedadController(ITipoPropiedadService _objService, IMapper _mapper)
        {
            this.objService = _objService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllTipoPropiedades
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTipoPropiedades))]
        public Result GetAllTipoPropiedades()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = objService.GetAllTipoPropiedades();
                var objModel = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<TipoPropiedadDto>>(objModel);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = true;
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
        /// GetTipoPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetTipoPropiedad))]
        public Result GetTipoPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = objService.GetTipoPropiedadById(Id);

                var lstTemp = mapper.Map<TipoPropiedadDto>(objModel);

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
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
        /// InsertTipoPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertTipoPropiedad))]
        public Result InsertTipoPropiedad(TipoPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                objService.InsertTipoPropiedad(customer);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Guardado";

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// UpdateTipoPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTipoPropiedad))]
        public Result UpdateTipoPropiedad(TipoPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                objService.UpdateTipoPropiedad(customer);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Actualizado";

            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        /// <summary>
        /// DeleteTipoPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTipoPropiedad))]
        public Result DeleteTipoPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                objService.DeleteTipoPropiedad(Id);

                oRespuesta.Success = true;
                oRespuesta.Message = "Registro Eliminado";

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
