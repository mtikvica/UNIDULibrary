using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Responses.BookResponse;
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

        CreateMap<BookCopy, BookCopyDto>().ReverseMap();

        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.PublisherName))
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.LocationName))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => new AuthorResponse() { AuthorName = x.AuthorName })));

        CreateMap<InventoryState, InventoryStateDto>().ReverseMap();

        CreateMap<Loan, LoanDto>().ReverseMap();

        CreateMap<Reservation, ReservationDto>().ReverseMap();
    }
}
