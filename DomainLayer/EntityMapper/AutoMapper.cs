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
            CreateMap<AgenteCreacionDto, Agente>()
                .ForMember(x => x.FotoPerfil, options => options.Ignore());

            CreateMap<Inmobiliaria, InmobiliariaDto>().ReverseMap();
            CreateMap<InmobiliariaDto, Inmobiliaria>();

            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<CiudadDto, Ciudad>();

            CreateMap<EstadoPropiedad, EstadoPropiedadDto>().ReverseMap();
            CreateMap<EstadoPropiedadDto, EstadoPropiedad>();

            CreateMap<Fotografia, FotografiaDto>().ReverseMap();
            CreateMap<FotografiaDto, Fotografia>();

            CreateMap<Propiedad, PropiedadDto>().ReverseMap();
            CreateMap<PropiedadDto, Propiedad>();

            CreateMap<TipoPropiedad, TipoPropiedadDto>().ReverseMap();
            CreateMap<TipoPropiedadDto, TipoPropiedad>();

            CreateMap<TipoOferta, TipoOfertaDto>().ReverseMap();
            CreateMap<TipoOfertaDto, TipoOferta>();

            CreateMap<Estrato, EstratoDto>().ReverseMap();
            CreateMap<EstratoDto, Estrato>();

            CreateMap<TiempoConstruido, TiempoConstruidoDto>().ReverseMap();
            CreateMap<TiempoConstruidoDto, TiempoConstruido>();

            CreateMap<TipoParqueadero, TipoParqueaderoDto>().ReverseMap();
            CreateMap<TipoParqueaderoDto, TipoParqueadero>();

            CreateMap<CaracteristicaParqueadero, CaracteristicaParqueaderoDto>().ReverseMap();
            CreateMap<CaracteristicaParqueaderoDto, CaracteristicaParqueadero>();

            CreateMap<NumeroBano, NumeroBanoDto>().ReverseMap();
            CreateMap<NumeroBanoDto, NumeroBano>();

            CreateMap<NumeroHabitacion, NumeroHabitacionDto>().ReverseMap();
            CreateMap<NumeroHabitacionDto, NumeroHabitacion>();

            CreateMap<NumeroParqueadero, NumeroParqueaderoDto>().ReverseMap();
            CreateMap<NumeroParqueaderoDto, NumeroParqueadero>();


            CreateMap<Agente, AgenteFullDto>().ReverseMap();
            CreateMap<AgenteFullDto, Agente>();

            CreateMap<Propiedad, PropiedadFullDto>().ReverseMap();
            CreateMap<PropiedadFullDto, Propiedad>();

            CreateMap<Caracteristica, CaracteristicaDto>().ReverseMap();
            CreateMap<CaracteristicaDto, Caracteristica>();
        }
    }
}
