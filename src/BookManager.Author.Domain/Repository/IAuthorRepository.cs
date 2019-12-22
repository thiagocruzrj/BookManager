using BookManager.Core.Data;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Author.Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(Guid id);
        Task<Author> GetByDoc(Document cpf);
        Task<Author> GetAllAuthorBooks(ICollection<Book> books);

        void Add(Author author);
        void Update(Author author);
    }
}
