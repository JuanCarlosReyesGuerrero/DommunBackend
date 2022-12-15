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
    public class CaracteristicaRepository : ICaracteristicaRepository
    {
        private readonly ApplicationDbContext objContext;

        EnviarLog enviarLog = new EnviarLog();

        private readonly IMapper mapper;

        public CaracteristicaRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> GetAllCaracteristicas()
        {
            Result oRespuesta = new Result();

            List<Caracteristica> listResult = new List<Caracteristica>();
            List<CaracteristicaDto> lstTemp = new List<CaracteristicaDto>();

            try
            {
                listResult = await objContext.Caracteristicas.ToListAsync();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<CaracteristicaDto>>(listResult);
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

        public async Task<Result> GetCaracteristicaById(int Id)
        {
            Result oRespuesta = new Result();

            List<Caracteristica> listResult = new List<Caracteristica>();

            CaracteristicaDto lstTemp = new CaracteristicaDto();

            try
            {
                listResult = await objContext.Caracteristicas.Where(x => x.Id == Id).ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<CaracteristicaDto>(item);
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

        public async Task<Result> InsertCaracteristica(CaracteristicaDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Caracteristica>(entity);                

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

        public async Task<Result> UpdateCaracteristica(CaracteristicaDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Caracteristica>(entity);

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

        public async Task<Result> DeleteCaracteristica(CaracteristicaDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Caracteristica>(entity);

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
