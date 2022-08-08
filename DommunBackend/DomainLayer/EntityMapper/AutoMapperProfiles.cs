using AutoMapper;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;

namespace DommunBackend.DomainLayer.EntityMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<DepartamentoDto, Departamento>();

            //CreateMap<Municipio, DepartamentoDto>().ReverseMap();
            //CreateMap<DepartamentoDto, Municipio>();
        }
    }
}
