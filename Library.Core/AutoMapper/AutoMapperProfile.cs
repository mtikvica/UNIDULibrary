using AutoMapper;
using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Automapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentDto, Department>();

        CreateMap<Location, LocationDto>();
        CreateMap<LocationDto, Location>();

        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
    }
}
