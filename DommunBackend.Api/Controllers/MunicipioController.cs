﻿using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        #region Property  
        private readonly IMunicipioService municipioService;
        private readonly IMapper mapper;
        #endregion

        #region Constructor  
        public MunicipioController(IMunicipioService _municipioService, IMapper _mapper)
        {
            this.municipioService = _municipioService;
            this.mapper = _mapper;
        }
        #endregion

        //[HttpGet(nameof(GetMunicipio))]
        //public IActionResult GetMunicipio(int id)
        //{
        //    var result = _municipioService.GetMunicipio(id);
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No records found");

        //}

        [HttpGet(nameof(GetAllMunicipio))]
        public async Task<Result> GetAllMunicipio()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = await Task.FromResult(municipioService.GetAllMunicipios());
                var municipios = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<MunicipioDto>>(municipios);

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

            //var queryTable = municipioService.GetAllMunicipios();
            //var municipios = queryTable.OrderBy(x => x.Nombre).ToList();

            //var result = mapper.Map<List<MunicipioDto>>(municipios);

            //if (result.Count > 0)
            //{
            //    return Ok(result);
            //}

            //return BadRequest("No records found");

        }

        //[HttpPost(nameof(InsertMunicipio))]
        //public IActionResult InsertMunicipio(Municipio municipio)
        //{
        //    _municipioService.InsertMunicipio(municipio);
        //    return Ok("Data inserted");

        //}
        //[HttpPut(nameof(UpdateMunicipio))]
        //public IActionResult UpdateMunicipio(Municipio municipio)
        //{
        //    _municipioService.UpdateMunicipio(municipio);
        //    return Ok("Updation done");

        //}
        //[HttpDelete(nameof(DeleteMunicipio))]
        //public IActionResult DeleteMunicipio(int Id)
        //{
        //    _municipioService.DeleteMunicipio(Id);
        //    return Ok("Data Deleted");

        //}
    }
}