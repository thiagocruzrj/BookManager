using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(Guid id);
        Task<Author> GetByDoc(string cpf);
        Task<IEnumerable<Author>> GetAllAuthorBooks(ICollection<Book> books);

        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
