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
    public class AgenteController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IAgenteService agenteService;
        private readonly IMapper mapper;

        public AgenteController(IAgenteService _agenteService, IMapper _mapper)
        {
            this.agenteService = _agenteService;
            this.mapper = _mapper;
        }

        /// <summary>
        /// GetAllAgentes
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllAgentes))]
        public Result GetAllAgentes()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = agenteService.GetAllAgentes();
                var objModel = queryTable.OrderBy(x => x.Nombres).ToList();

                var lstTemp = mapper.Map<List<AgenteDto>>(objModel);

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
        /// GetAgente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAgente))]
        public Result GetAgente(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                var objModel = agenteService.GetAgenteById(Id);

                var lstTemp = mapper.Map<AgenteDto>(objModel);

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
        /// InsertAgente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(InsertAgente))]
        public Result InsertAgente(Agente customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.InsertAgente(customer);

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
        /// UpdateAgente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateAgente))]
        public Result UpdateAgente(Agente customer)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.UpdateAgente(customer);

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
        /// DeleteAgente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteAgente))]
        public Result DeleteAgente(int Id)
        {
            Result oRespuesta = new Result();

            try
            {
                agenteService.DeleteAgente(Id);

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










        //[HttpGet(nameof(GetAgente))]
        //public IActionResult GetAgente(int id)
        //{
        //    var result = agenteService.GetAgente(id);
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest("No records found");
        //}


        //[HttpGet(nameof(GetAllAgentes))]
        //public IActionResult GetAllAgentes()
        //{
        //    var result = agenteService.GetAllAgentes();

        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest("No records found");
        //}

        //[HttpPost(nameof(InsertAgente))]
        //public IActionResult InsertAgente(Agente customer)
        //{
        //    agenteService.InsertAgente(customer);

        //    return Ok("Data inserted");
        //}

        //[HttpPut(nameof(UpdateAgente))]
        //public IActionResult UpdateAgente(Agente customer)
        //{
        //    agenteService.UpdateAgente(customer);

        //    return Ok("Updation done");
        //}

        //[HttpDelete(nameof(DeleteAgente))]
        //public IActionResult DeleteAgente(int Id)
        //{
        //    agenteService.DeleteAgente(Id);

        //    return Ok("Data Deleted");
        //}
    }
}
