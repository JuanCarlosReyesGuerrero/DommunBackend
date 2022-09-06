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
    public class FotografiaController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IFotografiaService agenteService;
        private readonly IMapper mapper;

        public FotografiaController(IFotografiaService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllFotografias
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllFotografias))]
        public Result GetAllFotografias()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllFotografias();
                var objModel = queryTable.OrderBy(x => x.Imagen).ToList();

                var lstTemp = mapper.Map<List<FotografiaDto>>(objModel);

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
        /// GetFotografia
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetFotografia))]
        public Result GetFotografia(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetFotografiaById(Id);

                var lstTemp = mapper.Map<FotografiaDto>(objModel);

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
        /// InsertFotografia
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertFotografia))]
        public Result InsertFotografia(Fotografia customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertFotografia(customer);

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
        /// UpdateFotografia
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateFotografia))]
        public Result UpdateFotografia(Fotografia customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateFotografia(customer);

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
        /// DeleteFotografia
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteFotografia))]
        public Result DeleteFotografia(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteFotografia(Id);

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
