using BookManager.Core.Data;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Catalog.Domain.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(Guid id);
        Task<IEnumerable<Book>> GetByIsbn(BookIdentificator isbn);
        Task<IEnumerable<Book>> GetByAuthor(Document cpf);
        Task<IEnumerable<Book>> GetByCategory(int code);

        void Add(Book book);
        void Update(Book book);
    }
}
