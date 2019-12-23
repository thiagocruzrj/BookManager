using BookManager.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public class BookAppService : IBookAppService
    {
        public void Add(BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> DebitStock(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookViewModel>> GetByAuthor(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookViewModel>> GetByCategory(int code)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookViewModel>> GetByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> RestoreStock(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Update(BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
