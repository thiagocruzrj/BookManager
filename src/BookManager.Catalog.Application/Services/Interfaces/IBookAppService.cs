using BookManager.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public interface IBookAppService : IDisposable
    {
        Task<IEnumerable<BookViewModel>> GetAll();
        Task<BookViewModel> GetById(Guid id);
        Task<IEnumerable<BookViewModel>> GetByIsbn(string isbn);
        Task<IEnumerable<BookViewModel>> GetByAuthor(string cpf);
        Task<IEnumerable<BookViewModel>> GetByCategory(int code);
        Task<BookViewModel> DebitStock(Guid id, int amount);
        Task<BookViewModel> RestoreStock(Guid id, int amount);

        void Add(BookViewModel bookViewModel);
        void Update(BookViewModel bookViewModel);
        void Delete(BookViewModel bookViewModel);
    }
}
