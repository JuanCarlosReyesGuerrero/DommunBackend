using AutoMapper;
using Commun;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
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

            List<Propiedad> listResult = new List<Propiedad>();
            List<PropiedadDto> lstTemp = new List<PropiedadDto>();

            try
            {
                var listPropiedad = (from x in objContext.Propiedades select x).ToList();
                var listCiudad = (from x in objContext.Ciudades select x).ToList();
                var listTipoPropiedad = (from x in objContext.TipoPropiedades select x).ToList();
                var listTipoOferta = (from x in objContext.TipoOfertas select x).ToList();
                var listEstrato = (from x in objContext.Estratos select x).ToList();
                var listAgente = (from x in objContext.Agentes select x).ToList();

                var listEstadoPropiedadDto = (from x in objContext.EstadoPropiedades select x).ToList();
                var listTiempoConstruidoDto = (from x in objContext.TiempoConstruidos select x).ToList();
                var listTipoParqueaderoDto = (from x in objContext.TipoParqueaderos select x).ToList();
                var listCaracteristicaParqueaderoDto = (from x in objContext.CaracteristicaParqueaderos select x).ToList();
                var listNumeroBanoDto = (from x in objContext.NumeroBanos select x).ToList();
                var listNumeroHabitacionDto = (from x in objContext.NumeroHabitaciones select x).ToList();
                var listNumeroParqueaderoDto = (from x in objContext.NumeroParqueaderos select x).ToList();


                listResult = (from pr in listPropiedad
                              join ag in listCiudad on pr.AgenteId equals ag.Id
                              join ci in listCiudad on pr.CiudadId equals ci.Id
                              join tp in listTipoPropiedad on pr.TipoPropiedadId equals tp.Id
                              join to in listTipoPropiedad on pr.TipoOfertaId equals to.Id
                              join es in listEstrato on pr.EstratoId equals es.Id
                              join ep in listEstadoPropiedadDto on pr.EstadoPropiedadId equals ep.Id
                              join tc in listTiempoConstruidoDto on pr.TiempoConstruidoId equals tc.Id
                              join tpa in listTipoParqueaderoDto on pr.TipoParqueaderoId equals tpa.Id
                              join cp in listCaracteristicaParqueaderoDto on pr.CaracteristicaParqueaderoId equals cp.Id
                              join nb in listNumeroBanoDto on pr.NumeroBanoId equals nb.Id
                              join nh in listNumeroHabitacionDto on pr.NumeroHabitacionId equals nh.Id
                              join np in listNumeroParqueaderoDto on pr.NumeroParqueaderoId equals np.Id
                              select pr).ToList();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<PropiedadDto>>(listResult);
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

        public async Task<Result> ObtenerPropiedadesById(int vId)
        {
            Result oRespuesta = new Result();

            List<Propiedad> listResult = new List<Propiedad>();
            List<PropiedadDto> lstTemp = new List<PropiedadDto>();

            try
            {
                var listPropiedad = (from x in objContext.Propiedades select x).ToList();
                var listCiudad = (from x in objContext.Ciudades select x).ToList();
                var listTipoPropiedad = (from x in objContext.TipoPropiedades select x).ToList();
                var listTipoOferta = (from x in objContext.TipoOfertas select x).ToList();
                var listEstrato = (from x in objContext.Estratos select x).ToList();
                var listAgente = (from x in objContext.Agentes select x).ToList();

                var listEstadoPropiedadDto = (from x in objContext.EstadoPropiedades select x).ToList();
                var listTiempoConstruidoDto = (from x in objContext.TiempoConstruidos select x).ToList();
                var listTipoParqueaderoDto = (from x in objContext.TipoParqueaderos select x).ToList();
                var listCaracteristicaParqueaderoDto = (from x in objContext.CaracteristicaParqueaderos select x).ToList();
                var listNumeroBanoDto = (from x in objContext.NumeroBanos select x).ToList();
                var listNumeroHabitacionDto = (from x in objContext.NumeroHabitaciones select x).ToList();
                var listNumeroParqueaderoDto = (from x in objContext.NumeroParqueaderos select x).ToList();


                listResult = (from pr in listPropiedad
                              join ag in listCiudad on pr.AgenteId equals ag.Id
                              join ci in listCiudad on pr.CiudadId equals ci.Id
                              join tp in listTipoPropiedad on pr.TipoPropiedadId equals tp.Id
                              join to in listTipoPropiedad on pr.TipoOfertaId equals to.Id
                              join es in listEstrato on pr.EstratoId equals es.Id
                              join ep in listEstadoPropiedadDto on pr.EstadoPropiedadId equals ep.Id
                              join tc in listTiempoConstruidoDto on pr.TiempoConstruidoId equals tc.Id
                              join tpa in listTipoParqueaderoDto on pr.TipoParqueaderoId equals tpa.Id
                              join cp in listCaracteristicaParqueaderoDto on pr.CaracteristicaParqueaderoId equals cp.Id
                              join nb in listNumeroBanoDto on pr.NumeroBanoId equals nb.Id
                              join nh in listNumeroHabitacionDto on pr.NumeroHabitacionId equals nh.Id
                              join np in listNumeroParqueaderoDto on pr.NumeroParqueaderoId equals np.Id
                              where pr.Id == vId
                              select pr).ToList();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<PropiedadDto>>(listResult);
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
