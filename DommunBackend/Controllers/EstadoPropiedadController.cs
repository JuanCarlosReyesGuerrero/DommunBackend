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
    public class EstadoPropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IEstadoPropiedadService agenteService;
        private readonly IMapper mapper;

        public EstadoPropiedadController(IEstadoPropiedadService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllEstadoPropiedades
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllEstadoPropiedades))]
        public Result GetAllEstadoPropiedades()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllEstadoPropiedades();
                var objModel = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<EstadoPropiedadDto>>(objModel);

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
        /// GetEstadoPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetEstadoPropiedad))]
        public Result GetEstadoPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetEstadoPropiedadById(Id);

                var lstTemp = mapper.Map<EstadoPropiedadDto>(objModel);

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
        /// InsertEstadoPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertEstadoPropiedad))]
        public Result InsertEstadoPropiedad(EstadoPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertEstadoPropiedad(customer);

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
        /// UpdateEstadoPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateEstadoPropiedad))]
        public Result UpdateEstadoPropiedad(EstadoPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateEstadoPropiedad(customer);

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
        /// DeleteEstadoPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteEstadoPropiedad))]
        public Result DeleteEstadoPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteEstadoPropiedad(Id);

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
