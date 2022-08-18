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
    public class CiudadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly ICiudadService agenteService;
        private readonly IMapper mapper;

        public CiudadController(ICiudadService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllCiudads
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCiudades))]
        public Result GetAllCiudades()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllCiudades();
                var objModel = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<CiudadDto>>(objModel);

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
        /// GetCiudad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetCiudad))]
        public Result GetCiudad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetCiudadById(Id);

                var lstTemp = mapper.Map<CiudadDto>(objModel);

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
        /// InsertCiudad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertCiudad))]
        public Result InsertCiudad(Ciudad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertCiudad(customer);

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
        /// UpdateCiudad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCiudad))]
        public Result UpdateCiudad(Ciudad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateCiudad(customer);

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
        /// DeleteCiudad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteCiudad))]
        public Result DeleteCiudad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteCiudad(Id);

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
