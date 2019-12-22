using BookManager.Core.Data;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Author.Domain.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(Guid id);
        Task<Book> GetByIsbn(BookIdentificator isbn);
        Task<Book> GetByAuthor(Document cpf);
        Task<Book> GetByCategory(int code);

        void Add(Book book);
        void Update(Book book);
    }
}
