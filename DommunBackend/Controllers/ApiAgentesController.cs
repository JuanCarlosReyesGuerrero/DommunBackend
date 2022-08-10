using AutoMapper;
using DommunBackend.Common.Logs;
using DommunBackend.Data;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DommunBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAgentesController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IAgenteService objService;
        private readonly IMapper mapper;

        public ApiAgentesController(IAgenteService _objService, IMapper _mapper)
        {
            this.objService = _objService;
            this.mapper = _mapper;
        }
        
        [HttpGet(nameof(GetAllAgentes))]
        public Result GetAllAgentes()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = objService.GetAllAgentes();
                var agentes = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<AgenteDto>>(agentes);

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

        //// GET: api/ApiAgentes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgenteDto()
        //{
        //  if (_context.AgenteDto == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.AgenteDto.ToListAsync();
        //}

        //// GET: api/ApiAgentes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AgenteDto>> GetAgenteDto(int id)
        //{
        //  if (_context.AgenteDto == null)
        //  {
        //      return NotFound();
        //  }
        //    var agenteDto = await _context.AgenteDto.FindAsync(id);

        //    if (agenteDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return agenteDto;
        //}

        //// PUT: api/ApiAgentes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAgenteDto(int id, AgenteDto agenteDto)
        //{
        //    if (id != agenteDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(agenteDto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AgenteDtoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ApiAgentes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<AgenteDto>> PostAgenteDto(AgenteDto agenteDto)
        //{
        //  if (_context.AgenteDto == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.AgenteDto'  is null.");
        //  }
        //    _context.AgenteDto.Add(agenteDto);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAgenteDto", new { id = agenteDto.Id }, agenteDto);
        //}

        //// DELETE: api/ApiAgentes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAgenteDto(int id)
        //{
        //    if (_context.AgenteDto == null)
        //    {
        //        return NotFound();
        //    }
        //    var agenteDto = await _context.AgenteDto.FindAsync(id);
        //    if (agenteDto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AgenteDto.Remove(agenteDto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AgenteDtoExists(int id)
        //{
        //    return (_context.AgenteDto?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
