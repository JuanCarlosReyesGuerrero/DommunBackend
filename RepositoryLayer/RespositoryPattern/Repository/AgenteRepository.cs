﻿using AutoMapper;
using Commun;
using Commun.Logs;
using DomainLayer.Dtos;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;

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

        public async Task<Result> GetAllAgentes()
        {
            Result oRespuesta = new Result();

            List<Agente> listResult = new List<Agente>();
            List<AgenteDto> lstTemp = new List<AgenteDto>();

            try
            {
                listResult = await objContext.Agentes
                    .Include(b => b.Propiedades)
                    .ToListAsync();

                if (listResult.Count > 0)
                {
                    lstTemp = mapper.Map<List<AgenteDto>>(listResult);
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

        public async Task<Result> GetAgenteById(int Id)
        {
            Result oRespuesta = new Result();

            List<Agente> listResult = new List<Agente>();

            AgenteDto lstTemp = new AgenteDto();

            try
            {
                listResult = await objContext.Agentes.Where(x => x.Id == Id)
                     .Include(b => b.Inmobiliaria)
                     .ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<AgenteDto>(item);
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

        public async Task<Result> InsertAgente(AgenteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                await objContext.AddAsync(entity);

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

        public async Task<Result> UpdateAgente(AgenteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                objContext.Update(entity);

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

        public async Task<Result> DeleteAgente(AgenteDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                objContext.Remove(entity);

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

        public async Task<Result> ObtenerAgentesFull()
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

        public async Task<Result> ObtenerAgenteFullById(int vId)
        {
            Result oRespuesta = new Result();

            List<Agente> listResult = new List<Agente>();

            AgenteDto lstTemp = new AgenteDto();

            try
            {
                listResult = await objContext.Agentes.Where(x => x.Id == vId)
                     .Include(b => b.Inmobiliaria)
                     .ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<AgenteDto>(item);
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
    }
}
