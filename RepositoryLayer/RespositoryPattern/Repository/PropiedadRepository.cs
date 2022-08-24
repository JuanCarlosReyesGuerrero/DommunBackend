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
                              select new Propiedad
                              {                                  
                                  TipoOfertaId = pr.TipoOfertaId,
                                  TipoPropiedadId = pr.TipoPropiedadId,
                                  ValorVenta = pr.ValorVenta,
                                  ValorArriendo = pr.ValorArriendo,
                                  IncluyeAdministracion = pr.IncluyeAdministracion,
                                  ValorAdministracion = pr.ValorAdministracion,
                                  ValorMetro = pr.ValorMetro,
                                  CiudadId = pr.CiudadId,
                                  Direccion = pr.Direccion,
                                  Barrio = pr.Barrio,
                                  Localizacion = pr.Localizacion,
                                  EstratoId = pr.EstratoId,
                                  AreaPrivada = pr.AreaPrivada,
                                  AreaConstruida = pr.AreaConstruida,
                                  NumeroPiso = pr.NumeroPiso,
                                  AreaFondo = pr.AreaFondo,
                                  TiempoConstruidoId = pr.TiempoConstruidoId,
                                  NumeroHabitacionId = pr.NumeroHabitacionId,
                                  NumeroBanoId = pr.NumeroBanoId,
                                  NumeroParqueaderoId = pr.NumeroParqueaderoId,
                                  TipoParqueaderoId = pr.TipoParqueaderoId,
                                  CaracteristicaParqueaderoId = pr.CaracteristicaParqueaderoId,
                                  Caracteristicas = pr.Caracteristicas,
                                  Video = pr.Video,
                                  Descripcion = pr.Descripcion,
                                  AnioConstruccion = pr.AnioConstruccion,
                                  EstadoPropiedadId = pr.EstadoPropiedadId,
                                  AgenteId = pr.AgenteId,
                                  IsActive = pr.IsActive,

                                  Agente = new Agente
                                  {
                                      Slug = ag.Slug,
                                      Nombres = ag.Nombres,
                                      Apellidos = ag.Apellidos,
                                      Email = ag.Email,
                                      FotoPerfil = ag.FotoPerfil,
                                      DescripcionPerfil = ag.DescripcionPerfil,
                                      Celular = ag.Celular,
                                      Facebook = ag.Facebook,
                                      Twitter = ag.Twitter,
                                      Linkedin = ag.Linkedin,
                                      Instagram = ag.Instagram,
                                      Website = ag.Website,
                                      InmobiliariaId = ag.InmobiliariaId,
                                      Inmobiliaria = ag.Inmobiliaria,
                                      Propiedades = ag.Propiedades,
                                      Id = ag.Id,
                                      CreatedDate = ag.CreatedDate,
                                      ModifiedDate = ag.ModifiedDate,
                                      CreateUser = ag.CreateUser,
                                      ModifiedUser = ag.ModifiedUser,
                                      IsActive = ag.IsActive,
                                  }
                              }).ToList();

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
