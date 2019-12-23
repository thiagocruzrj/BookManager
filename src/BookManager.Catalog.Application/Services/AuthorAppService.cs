using BookManager.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        public void Add(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorViewModel>> GetAllAuthorBooks(ICollection<BookViewModel> books)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorViewModel>> GetByDoc(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorViewModel>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
