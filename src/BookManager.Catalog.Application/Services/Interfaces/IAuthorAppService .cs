using BookManager.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public interface IAuthorAppService : IDisposable
    {
        Task<IEnumerable<AuthorViewModel>> GetAll();
        Task<IEnumerable<AuthorViewModel>> GetById(Guid id);
        Task<IEnumerable<AuthorViewModel>> GetByDoc(string cpf);
        Task<IEnumerable<AuthorViewModel>> GetAllAuthorBooks(ICollection<BookViewModel> books);

        void Add(AuthorViewModel authorViewModel);
        void Update(AuthorViewModel authorViewModel);
        void Delete(AuthorViewModel authorViewModel);
    }
}
