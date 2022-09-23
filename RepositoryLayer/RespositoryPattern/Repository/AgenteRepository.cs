using AutoMapper;
using Commun.Logs;
using Commun;
using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.RespositoryPattern.Repository
{
    public class AgenteRepository : IAgenteRepository
    {
        private readonly ApplicationDbContext objContext;

        EnviarLog enviarLog = new EnviarLog();

        private readonly IMapper mapper;

        public AgenteRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> ObtenerAgentes()
        {
            Result oRespuesta = new Result();

            List<Agente> listResult = new List<Agente>();
            List<AgenteFullDto> lstTemp = new List<AgenteFullDto>();

            try
            {
                listResult = await objContext.Agentes
                    .Include(b => b.Propiedades)
                    .ToListAsync();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<AgenteFullDto>>(listResult);
                }
                else
                {
                    lstTemp = null;
                }

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> ObtenerAgenteById(int vId)
        {
            Result oRespuesta = new Result();

            List<Agente> listResult = new List<Agente>();
            List<AgenteFullDto> lstTemp = new List<AgenteFullDto>();

            try
            {
                listResult = await objContext.Agentes.Where(x => x.Id == vId)
                     .Include(b => b.Propiedades)
                     .ToListAsync();               

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<AgenteFullDto>>(listResult);
                }
                else
                {
                    lstTemp = null;
                }

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
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
