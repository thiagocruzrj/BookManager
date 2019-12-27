using BookManager.Application.ViewModels;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Application.Services
{
    public interface IBookAppService : IDisposable
    {
        Task<IEnumerable<BookViewModel>> GetAll();
        Task<BookViewModel> GetById(Guid id);
        Task<BookViewModel> GetByIsbn(BookIdentificator isbn);
        Task<BookViewModel> GetByAuthor(Document cpf);
        Task<BookViewModel> GetByCategory(int code);
        Task<BookViewModel> DebitStock(Guid id, int amount);
        Task<BookViewModel> RestoreStock(Guid id, int amount);

        Task Add(BookViewModel bookViewModel);
        Task Update(BookViewModel bookViewModel);
        Task Delete(BookViewModel bookViewModel);
    }
}
