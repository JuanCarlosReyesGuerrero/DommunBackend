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
    public class NumeroBanoController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly INumeroBanoService numeroBanoService;
        private readonly IMapper mapper;

        public NumeroBanoController(INumeroBanoService _numeroBanoService, IMapper _mapper)
        {
            this.numeroBanoService = _numeroBanoService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllNumeroBanos
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllNumeroBanos))]
        public Result GetAllNumeroBanos()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = numeroBanoService.GetAllNumeroBanos();

                var lstTemp = mapper.Map<List<NumeroBanoDto>>(queryTable.Result.Data);

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
        /// GetNumeroBano
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetNumeroBano))]
        public Result GetNumeroBano(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = numeroBanoService.GetNumeroBanoById(Id);

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
        /// InsertNumeroBano
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertNumeroBano))]
        public Result InsertNumeroBano(NumeroBanoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.CreatedDate = DateTime.Now;

                var vRespuesta = numeroBanoService.InsertNumeroBano(objModel);

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
        /// UpdateNumeroBano
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateNumeroBano))]
        public Result UpdateNumeroBano(NumeroBanoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                objModel.ModifiedDate = DateTime.Now;

                var vRespuesta = numeroBanoService.UpdateNumeroBano(objModel);

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
        /// DeleteNumeroBano
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteNumeroBano))]
        public Result DeleteNumeroBano(NumeroBanoDto objModel)
        {
            Result oRespuesta = new Result();

            try
            {
                var vRespuesta = numeroBanoService.DeleteNumeroBano(objModel);

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
