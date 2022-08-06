using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;

namespace DomainLayer.EntityMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<DepartamentoDto, Departamento>();

            CreateMap<Municipio, DepartamentoDto>().ReverseMap();
            CreateMap<DepartamentoDto, Municipio>();
        }
    }
}
