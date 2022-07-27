using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        #region Property  
        private readonly IDepartamentoService departamentoService;
        private readonly IMapper mapper;
        #endregion

        #region Constructor  
        public DepartamentoController(IDepartamentoService _departamentoService, IMapper _mapper)
        {
            this.departamentoService = _departamentoService;
            this.mapper = _mapper;
        }
        #endregion

        //[HttpGet(nameof(GetDepartamento))]
        //public IActionResult GetDepartamento(int id)
        //{
        //    var result = _departamentoService.GetDepartamento(id);
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No records found");

        //}

        [HttpGet(nameof(GetAllDepartamento))]
        public Result GetAllDepartamento()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = departamentoService.GetAllDepartamentos();
                var departamentos = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<DepartamentoDTO>>(departamentos);

                if (lstTemp.Count >= 0)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }               
            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;







            //var queryTable = departamentoService.GetAllDepartamentos();
            //var departamentos = queryTable.OrderBy(x => x.Nombre).ToList();

            //var result = mapper.Map<List<DepartamentoDTO>>(departamentos);

            //if (result.Count > 0)
            //{
            //    return Ok(result);
            //}

            //return BadRequest("No records found");

        }

        //[HttpPost(nameof(InsertDepartamento))]
        //public IActionResult InsertDepartamento(Departamento departamento)
        //{
        //    _departamentoService.InsertDepartamento(departamento);
        //    return Ok("Data inserted");

        //}
        //[HttpPut(nameof(UpdateDepartamento))]
        //public IActionResult UpdateDepartamento(Departamento departamento)
        //{
        //    _departamentoService.UpdateDepartamento(departamento);
        //    return Ok("Updation done");

        //}
        //[HttpDelete(nameof(DeleteDepartamento))]
        //public IActionResult DeleteDepartamento(int Id)
        //{
        //    _departamentoService.DeleteDepartamento(Id);
        //    return Ok("Data Deleted");

        //}
    }
}