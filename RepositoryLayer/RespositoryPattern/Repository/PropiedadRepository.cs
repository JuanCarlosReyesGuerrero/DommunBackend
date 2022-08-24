using AutoMapper;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern.Interface;

namespace RepositoryLayer.RespositoryPattern.Repository
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private readonly ApplicationDbContext objContext;

        EnviarLog enviarLog = new EnviarLog();

        private readonly IMapper mapper;

        public PropiedadRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> ObtenerPropiedades()
        {
            Result oRespuesta = new Result();

            try
            {
                var result = (from pr in objContext.Propiedades
                              join ag in objContext.Agentes on pr.AgenteId equals ag.Id
                              select new PropiedadDto
                              {
                                  Agente = new AgenteDto
                                  {
                                      FotoPerfil = ag.FotoPerfil,
                                  } 
                              } ).ToList();

                var lstTemp = mapper.Map<List<PropiedadDto>>(result);

                if (result != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = result;
                }
                else
                {
                    oRespuesta.Success = false;
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
