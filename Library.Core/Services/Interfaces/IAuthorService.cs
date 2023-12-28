using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IAuthorService
{
    Task<Author> AddAuthorAsync(AuthorDto authorDto);
}