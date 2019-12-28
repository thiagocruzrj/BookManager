using BookManager.Application.ViewModels;
using BookManager.Core.DomainObjects.ValueObjects;
using BookManager.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Application.Services
{
    public interface IAuthorAppService : IDisposable
    {
        Task<IEnumerable<AuthorViewModel>> GetAll();
        Task<AuthorViewModel> GetById(Guid id);
        Task<AuthorViewModel> GetByDoc(Document cpf);
        Task<IEnumerable<AuthorViewModel>> GetAllAuthorBooks(ICollection<Book> books);

        Task Add(AuthorViewModel authorViewModel);
        Task Update(AuthorViewModel authorViewModel);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
