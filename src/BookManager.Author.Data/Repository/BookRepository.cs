using BookManager.Catalog.Domain;
using BookManager.Catalog.Domain.Repository;
using BookManager.Core.Data;
using BookManager.Core.DomainObjects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly CatalogContext _context;

        public BookRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByAuthor(Document cpf)
        {
            return await _context.Books.AsNoTracking().Include(b => b.Author).Where(a => a.Author.Cpf == cpf).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetByIsbn(BookIdentificator isbn)
        {
            return await _context.Books.AsNoTracking().Include(b => b.Isbn).Where(a => a.Isbn == isbn).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByCategory(int code)
        {
            return await _context.Books.AsNoTracking().Include(b => b.Category).Where(a => a.Category.Code == code).ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
