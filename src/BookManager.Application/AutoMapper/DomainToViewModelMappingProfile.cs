using AutoMapper;
using BookManager.Application.ViewModels;
using BookManager.Core.DomainObjects.ValueObjects;
using BookManager.Domain;

namespace BookManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BookViewModel, Book>()
                .ConstructUsing(p => new Book(p.CategoryId, p.AuthorId , p.Title, p.ReleaseDate, new BookIdentificator(p.Isbn), p.RegisterDate));

            CreateMap<AuthorViewModel, Author>()
                .ConstructUsing(p => new Author(new Document(p.Cpf), p.Name, p.Birthdate));

            CreateMap<CategoryViewModel, Category>()
                .ConstructUsing(p => new Category(p.Name, p.Code));
        }
    }
}
