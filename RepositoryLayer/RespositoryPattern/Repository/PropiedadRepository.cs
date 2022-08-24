using AutoMapper;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
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
                var listPropiedad = (from x in objContext.Propiedades select x).ToList();
                var listCiudad = (from x in objContext.Ciudades select x).ToList();
                var listTipoPropiedad = (from x in objContext.TipoPropiedades select x).ToList();
                var listTipoOferta = (from x in objContext.TipoOfertas select x).ToList();
                var listEstrato = (from x in objContext.Estratos select x).ToList();
                var listAgente = (from x in objContext.Agentes select x).ToList();

                var result = (from pr in listPropiedad
                              join ag in listCiudad on pr.AgenteId equals ag.Id
                              join ci in listCiudad on pr.CiudadId equals ci.Id
                              join tp in listTipoPropiedad on pr.TipoPropiedadId equals tp.Id
                              join to in listTipoPropiedad on pr.TipoOfertaId equals to.Id
                              join es in listEstrato on pr.EstratoId equals es.Id
                              select pr).ToList();               

                var lstTemp = mapper.Map<List<PropiedadDto>>(result);

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
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
