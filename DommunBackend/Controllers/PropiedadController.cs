using AutoMapper;
using Commun;
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
                var queryTable = propiedadService.GetAllPropiedades();

                var lstTemp = mapper.Map<List<PropiedadDto>>(queryTable.Result.Data);

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
        /// InsertPropiedad
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertPropiedad))]
        public Result InsertPropiedad(PropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = propiedadService.InsertPropiedad(objModel);

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
        /// UpdatePropiedad
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdatePropiedad))]
        public Result UpdatePropiedad(PropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = propiedadService.UpdatePropiedad(objModel);

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
        /// DeletePropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeletePropiedad))]
        public Result DeletePropiedad(PropiedadDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = propiedadService.DeletePropiedad(objModel);

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
