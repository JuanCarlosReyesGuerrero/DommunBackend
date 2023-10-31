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
    public class NumeroHabitacionRepository : INumeroHabitacionRepository
    {
        private readonly ApplicationDbContext objContext;

       private readonly ICreateLogger _createLogger;

        private readonly IMapper mapper;

        public NumeroHabitacionRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> GetAllNumeroHabitaciones()
        {
            Result oRespuesta = new Result();

            List<NumeroHabitacion> listResult = new List<NumeroHabitacion>();
            List<NumeroHabitacionDto> lstTemp = new List<NumeroHabitacionDto>();

            try
            {
                listResult = await objContext.NumeroHabitaciones.ToListAsync();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<NumeroHabitacionDto>>(listResult);
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
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> GetNumeroHabitacionById(int Id)
        {
            Result oRespuesta = new Result();

            List<NumeroHabitacion> listResult = new List<NumeroHabitacion>();

            NumeroHabitacionDto lstTemp = new NumeroHabitacionDto();

            try
            {
                listResult = await objContext.NumeroHabitaciones.Where(x => x.Id == Id).ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<NumeroHabitacionDto>(item);
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
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> InsertNumeroHabitacion(NumeroHabitacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<NumeroHabitacion>(entity);                

                await objContext.AddAsync(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegGuardado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> UpdateNumeroHabitacion(NumeroHabitacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<NumeroHabitacion>(entity);

                objContext.Update(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegActualizado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> DeleteNumeroHabitacion(NumeroHabitacionDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<NumeroHabitacion>(entity);

                objContext.Remove(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegEliminado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }       
    }
}
