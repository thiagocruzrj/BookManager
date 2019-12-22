using BookManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Author.Domain
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(Guid id);
        Task<IEnumerable<Book>> GetByCategory(int code);
        Task<IEnumerable<Category>> GetCategories();

        void Add(Book book);
        void Update(Book book);
        void Add(Category category);
    }
}
