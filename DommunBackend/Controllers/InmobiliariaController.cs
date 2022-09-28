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
    public class InmobiliariaController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IInmobiliariaService inmobiliariaService;
        private readonly IMapper mapper;

        public InmobiliariaController(IInmobiliariaService _inmobiliariaService, IMapper _mapper)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllInmobiliarias
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllInmobiliarias))]
        public Result GetAllInmobiliarias()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = inmobiliariaService.GetAllInmobiliarias();
                var objModel = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<InmobiliariaDto>>(objModel);

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
        /// GetInmobiliaria
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetInmobiliaria))]
        public Result GetInmobiliaria(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = inmobiliariaService.GetInmobiliariaById(Id);

                var lstTemp = mapper.Map<InmobiliariaDto>(objModel);

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
        /// InsertInmobiliaria
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertInmobiliaria))]
        public Result InsertInmobiliaria(Inmobiliaria objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                inmobiliariaService.InsertInmobiliaria(objModel);

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
        /// UpdateInmobiliaria
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateInmobiliaria))]
        public Result UpdateInmobiliaria(Inmobiliaria objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                inmobiliariaService.UpdateInmobiliaria(objModel);

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
        /// DeleteInmobiliaria
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteInmobiliaria))]
        public Result DeleteInmobiliaria(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                inmobiliariaService.DeleteInmobiliaria(Id);

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