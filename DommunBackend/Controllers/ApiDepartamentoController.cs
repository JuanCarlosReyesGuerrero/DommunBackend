using AutoMapper;
using DommunBackend.Common.Logs;
using DommunBackend.Data;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DommunBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDepartamentoController : ControllerBase
    {
        EnviarLog enviarLog = new EnviarLog();

        private readonly IDepartamentoService departamentoService;
        private readonly IMapper mapper;

        private readonly ApplicationDbContext _context;

        public ApiDepartamentoController(IDepartamentoService _departamentoService, IMapper _mapper)
        {
            this.departamentoService = _departamentoService;
            this.mapper = _mapper;
        }

        [HttpGet(nameof(GetAllDepartamento))]
        public Result GetAllDepartamento()
        {
            Result oRespuesta = new Result();

            try
            {
                var queryTable = departamentoService.GetAllDepartamentos();
                var departamentos = queryTable.OrderBy(x => x.Nombre).ToList();

                var lstTemp = mapper.Map<List<DepartamentoDto>>(departamentos);

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











        //// GET: api/ApiDepartamentos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepartamentoDto()
        //{
        //  if (_context.DepartamentoDto == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.DepartamentoDto.ToListAsync();
        //}

        //// GET: api/ApiDepartamentos/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DepartamentoDto>> GetDepartamentoDto(int id)
        //{
        //  if (_context.DepartamentoDto == null)
        //  {
        //      return NotFound();
        //  }
        //    var departamentoDto = await _context.DepartamentoDto.FindAsync(id);

        //    if (departamentoDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return departamentoDto;
        //}

        //// PUT: api/ApiDepartamentos/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDepartamentoDto(int id, DepartamentoDto departamentoDto)
        //{
        //    if (id != departamentoDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(departamentoDto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartamentoDtoExists(id))
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

        //// POST: api/ApiDepartamentos
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DepartamentoDto>> PostDepartamentoDto(DepartamentoDto departamentoDto)
        //{
        //  if (_context.DepartamentoDto == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.DepartamentoDto'  is null.");
        //  }
        //    _context.DepartamentoDto.Add(departamentoDto);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDepartamentoDto", new { id = departamentoDto.Id }, departamentoDto);
        //}

        //// DELETE: api/ApiDepartamentos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDepartamentoDto(int id)
        //{
        //    if (_context.DepartamentoDto == null)
        //    {
        //        return NotFound();
        //    }
        //    var departamentoDto = await _context.DepartamentoDto.FindAsync(id);
        //    if (departamentoDto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DepartamentoDto.Remove(departamentoDto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DepartamentoDtoExists(int id)
        //{
        //    return (_context.DepartamentoDto?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
