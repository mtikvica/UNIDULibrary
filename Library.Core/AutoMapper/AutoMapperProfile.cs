using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Responses.StudentResponses;
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

        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();

        CreateMap<Student, StudentResponse>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.DepartmentName));
    }
}
