using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Responses.StudentResponses;
using Library.Data.Entities;

namespace Library.Core.Automapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();

        CreateMap<Book, BookDto>().ReverseMap();

        CreateMap<Department, DepartmentDto>().ReverseMap();

        CreateMap<Location, LocationDto>().ReverseMap();

        CreateMap<Publisher, PublisherDto>().ReverseMap();

        CreateMap<Student, StudentDto>().ReverseMap();

        CreateMap<Student, StudentResponse>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.DepartmentName));

        CreateMap<Staff, StaffDto>().ReverseMap();
    }
}
