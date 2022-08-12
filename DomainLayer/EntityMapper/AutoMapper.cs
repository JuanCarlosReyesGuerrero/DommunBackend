using AutoMapper;
using DomainLayer.Dtos;
using DomainLayer.Models;

namespace DomainLayer.EntityMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Agente, AgenteDto>().ReverseMap();
            CreateMap<AgenteDto, Agente>();

            CreateMap<Inmobiliaria, InmobiliariaDto>().ReverseMap();
            CreateMap<InmobiliariaDto, Inmobiliaria>();
        }
    }
}
