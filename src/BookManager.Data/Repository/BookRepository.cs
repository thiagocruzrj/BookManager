using BookManager.Domain;
using BookManager.Domain.Repository;
using BookManager.Core.Data;
using BookManager.Core.DomainObjects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly CatalogContext _context;
        protected readonly DbSet<Book> DbSet;

        public BookRepository(CatalogContext context)
        {
            _context = context;
            DbSet = _context.Set<Book>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByAuthor(Document cpf)
        {
            return await DbSet.FindAsync(cpf);
        }
        public async Task<Book> GetByIsbn(BookIdentificator isbn)
        {
            return await DbSet.FindAsync(isbn);
        }

        public async Task<IEnumerable<Book>> GetByCategory(int code)
        {
            return await DbSet.AsNoTracking().Include(b => b.Category).Where(a => a.Category.Code == code).ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Book book)
        {
            DbSet.Add(book);
        }

        public void Update(Book book)
        {
            DbSet.Update(book);
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
