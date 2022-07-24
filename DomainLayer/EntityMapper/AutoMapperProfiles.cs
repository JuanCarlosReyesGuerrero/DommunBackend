using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;

namespace DomainLayer.EntityMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<Municipio, MunicipioDTO>().ReverseMap();
            CreateMap<MunicipioDTO, Municipio>();
        }
    }
}
