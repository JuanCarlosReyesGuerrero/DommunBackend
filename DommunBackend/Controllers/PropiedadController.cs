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
    public class PropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IPropiedadService agenteService;
        private readonly IMapper mapper;

        public PropiedadController(IPropiedadService _agenteService, IMapper _mapper)
        {
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
                var queryTable = agenteService.GetAllPropiedades();
                var objModel = queryTable.OrderBy(x => x.Titulo).ToList();

                var lstTemp = mapper.Map<List<PropiedadDto>>(objModel);
                
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
                var objModel = agenteService.GetPropiedadById(Id);

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
                agenteService.InsertPropiedad(customer);

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
                agenteService.UpdatePropiedad(customer);

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
                agenteService.DeletePropiedad(Id);

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
