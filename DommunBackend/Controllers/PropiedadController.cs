using AutoMapper;
using Commun;
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
    public class PropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IPropiedadService propiedadService;
        private readonly IAgenteService agenteService;
        private readonly IMapper mapper;

        public PropiedadController(IPropiedadService _propiedadService, IAgenteService _agenteService, IMapper _mapper)
        {
            this.propiedadService = _propiedadService;
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllPropiedads
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllPropiedades))]
        public Result GetAllPropiedades()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = propiedadService.GetAllPropiedades().ToList();

                var lstTemp = mapper.Map<List<PropiedadDto>>(queryTable);

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
        /// GetPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetPropiedad))]
        public Result GetPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = propiedadService.GetPropiedadById(Id);

                var lstTemp = mapper.Map<PropiedadDto>(objModel);

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
        /// InsertPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertPropiedad))]
        public Result InsertPropiedad(Propiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                propiedadService.InsertPropiedad(customer);

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
        /// UpdatePropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdatePropiedad))]
        public Result UpdatePropiedad(Propiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                propiedadService.UpdatePropiedad(customer);

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
        /// DeletePropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeletePropiedad))]
        public Result DeletePropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                propiedadService.DeletePropiedad(Id);

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


        [HttpGet(nameof(GetPropiedadesFull))]
        public async Task<IActionResult> GetPropiedadesFull()
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = await propiedadService.ObtenerPropiedades();

                if (vRespuesta.Success == true)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Message = Constantes.msjLoginCorrecto;
                    oRespuesta.Data = vRespuesta.Data;

                    return Ok(oRespuesta);
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjLoginErrado;

                    return Ok(oRespuesta);
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;

                return BadRequest();
            }
        }
    }
}
