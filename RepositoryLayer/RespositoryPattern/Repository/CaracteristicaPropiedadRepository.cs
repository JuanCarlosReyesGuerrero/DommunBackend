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
    public class CaracteristicaPropiedadRepository : ICaracteristicaPropiedadRepository
    {
        private readonly ApplicationDbContext objContext;

       private readonly ICreateLogger _createLogger;

        private readonly IMapper mapper;

        public CaracteristicaPropiedadRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> GetAllCaracteristicaPropiedades()
        {
            Result oRespuesta = new Result();

            List<CaracteristicaPropiedad> listResult = new List<CaracteristicaPropiedad>();
            List<CaracteristicaPropiedadDto> lstTemp = new List<CaracteristicaPropiedadDto>();

            try
            {
                listResult = await objContext.CaracteristicaPropiedades.ToListAsync();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<CaracteristicaPropiedadDto>>(listResult);
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

        public async Task<Result> GetCaracteristicaPropiedadById(int Id)
        {
            Result oRespuesta = new Result();

            List<CaracteristicaPropiedad> listResult = new List<CaracteristicaPropiedad>();

            CaracteristicaPropiedadDto lstTemp = new CaracteristicaPropiedadDto();

            try
            {
                listResult = await objContext.CaracteristicaPropiedades.Where(x => x.Id == Id).ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<CaracteristicaPropiedadDto>(item);
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

        public async Task<Result> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<CaracteristicaPropiedad>(entity);                

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

        public async Task<Result> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<CaracteristicaPropiedad>(entity);

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

        public async Task<Result> DeleteCaracteristicaPropiedad(CaracteristicaPropiedadDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<CaracteristicaPropiedad>(entity);

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
