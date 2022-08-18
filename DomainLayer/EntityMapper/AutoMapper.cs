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

            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<CiudadDto, Ciudad>();

            CreateMap<EstadoPropiedad, EstadoPropiedadDto>().ReverseMap();
            CreateMap<EstadoPropiedadDto, EstadoPropiedad>();

            CreateMap<Fotografia, FotografiaDto>().ReverseMap();
            CreateMap<FotografiaDto, Fotografia>();

            CreateMap<FotografiaPropiedad, FotografiaPropiedadDto>().ReverseMap();
            CreateMap<FotografiaPropiedadDto, FotografiaPropiedad>();

            CreateMap<Propiedad, PropiedadDto>().ReverseMap();
            CreateMap<PropiedadDto, Propiedad>();

            CreateMap<TipoPropiedad, TipoPropiedadDto>().ReverseMap();
            CreateMap<TipoPropiedadDto, TipoPropiedad>();
        }
    }
}
