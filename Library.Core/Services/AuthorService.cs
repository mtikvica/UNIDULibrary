using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Core.Services;
public class AuthorService(IAuthorRepository authorRepository, IMapper mapper) : IAuthorService
{
    private readonly IAuthorRepository _authorRepository = authorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Author> AddAuthorAsync(AuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        return await _authorRepository.AddAsync(author);
    }
}
