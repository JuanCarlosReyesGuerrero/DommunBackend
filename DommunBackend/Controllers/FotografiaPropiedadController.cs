using AutoMapper;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interface;

namespace DommunBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FotografiaPropiedadController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IFotografiaPropiedadService agenteService;
        private readonly IMapper mapper;

        public FotografiaPropiedadController(IFotografiaPropiedadService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllFotografiaPropiedads
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllFotografiaPropiedades))]
        public Result GetAllFotografiaPropiedades()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllFotografiaPropiedades();
                var objModel = queryTable.OrderBy(x => x.FotografiaId).ToList();

                var lstTemp = mapper.Map<List<FotografiaPropiedadDto>>(objModel);

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
        /// GetFotografiaPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetFotografiaPropiedad))]
        public Result GetFotografiaPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetFotografiaPropiedadById(Id);

                var lstTemp = mapper.Map<FotografiaPropiedadDto>(objModel);

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
        /// InsertFotografiaPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertFotografiaPropiedad))]
        public Result InsertFotografiaPropiedad(FotografiaPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertFotografiaPropiedad(customer);

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
        /// UpdateFotografiaPropiedad
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateFotografiaPropiedad))]
        public Result UpdateFotografiaPropiedad(FotografiaPropiedad customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateFotografiaPropiedad(customer);

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
        /// DeleteFotografiaPropiedad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteFotografiaPropiedad))]
        public Result DeleteFotografiaPropiedad(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteFotografiaPropiedad(Id);

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
