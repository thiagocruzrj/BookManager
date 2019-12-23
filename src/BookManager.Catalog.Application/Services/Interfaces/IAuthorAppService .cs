using BookManager.Catalog.Application.ViewModels;
using BookManager.Catalog.Domain;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public interface IAuthorAppService : IDisposable
    {
        Task<IEnumerable<AuthorViewModel>> GetAll();
        Task<IEnumerable<AuthorViewModel>> GetById(Guid id);
        Task<IEnumerable<AuthorViewModel>> GetByDoc(Document cpf);
        Task<IEnumerable<AuthorViewModel>> GetAllAuthorBooks(ICollection<Book> books);

        Task Add(AuthorViewModel authorViewModel);
        Task Update(AuthorViewModel authorViewModel);
        Task Delete(AuthorViewModel authorViewModel);
        Task<int> SaveChanges();
    }
}
