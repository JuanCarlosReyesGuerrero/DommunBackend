using AutoMapper;
using Commun;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;

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

        public async Task<Result> GetAllPropiedades()
        {
            Result oRespuesta = new Result();

            List<Propiedad> listResult = new List<Propiedad>();
            List<PropiedadDto> lstTemp = new List<PropiedadDto>();

            try
            {
                listResult = await objContext.Propiedades
                    .Include(b => b.Ciudad)
                    .Include(b => b.TipoPropiedad)
                    .Include(b => b.TipoOferta)
                    .Include(b => b.Estrato)
                    .Include(b => b.Agente)
                    .Include(b => b.EstadoPropiedad)
                    .Include(b => b.TiempoConstruido)
                    .Include(b => b.TipoParqueadero)
                    .Include(b => b.CaracteristicaParqueadero)
                    .Include(b => b.NumeroBano)
                    .Include(b => b.NumeroHabitacion)
                    .Include(b => b.NumeroParqueadero)
                    .ToListAsync();

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

        public async Task<Result> GetPropiedadById(int Id)
        {
            Result oRespuesta = new Result();

            List<Propiedad> listResult = new List<Propiedad>();
            PropiedadDto lstTemp = new PropiedadDto();

            try
            {
                listResult = await objContext.Propiedades.Where(x => x.Id == Id)
                    .Include(b => b.Ciudad)
                    .Include(b => b.TipoPropiedad)
                    .Include(b => b.TipoOferta)
                    .Include(b => b.Estrato)
                    .Include(b => b.Agente)
                    .Include(b => b.EstadoPropiedad)
                    .Include(b => b.TiempoConstruido)
                    .Include(b => b.TipoParqueadero)
                    .Include(b => b.CaracteristicaParqueadero)
                    .Include(b => b.NumeroBano)
                    .Include(b => b.NumeroHabitacion)
                    .Include(b => b.NumeroParqueadero)
                    .ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<PropiedadDto>(item);
                    }
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

        public async Task<Result> InsertPropiedad(PropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Propiedad>(entity);

                await objContext.AddAsync(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegGuardado;
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> UpdatePropiedad(PropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Propiedad>(entity);

                objContext.Update(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegActualizado;
            }
            catch (Exception ex)
            {
                enviarLog.EnviarExcepcion(ex.Message, ex);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> DeletePropiedad(PropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Propiedad>(entity);

                objContext.Remove(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegEliminado;
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
