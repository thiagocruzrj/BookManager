using BookManager.Catalog.Domain;
using BookManager.Catalog.Domain.Repository;
using BookManager.Core.DomainObjects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CatalogContext _context;
        public AuthorRepository(CatalogContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorBooks(ICollection<Book> books)
        {
            return await _context.Authors.AsNoTracking().Include(b => b.Books).Where(a => a.Books == books).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetByDoc(Document cpf)
        {
            return await _context.Authors.AsNoTracking().Include(b => b.Cpf).Where(a => a.Cpf == cpf).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetById(Guid id)
        {
            return await _context.Authors.AsNoTracking().Include(b => b.Id).Where(a => a.Id == id).ToListAsync();
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
        }
    }
}
