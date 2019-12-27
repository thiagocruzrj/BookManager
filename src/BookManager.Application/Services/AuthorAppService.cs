
using AutoMapper;
using BookManager.Application.ViewModels;
using BookManager.Core.DomainObjects.ValueObjects;
using BookManager.Data;
using BookManager.Domain;
using BookManager.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        protected readonly CatalogContext Db;

        public AuthorAppService(IAuthorRepository authorRepository, IMapper mapper, CatalogContext db)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            Db = db;
        }

        public async Task Add(AuthorViewModel authorViewModel)
        {
            var author = _mapper.Map<Author>(authorViewModel);
            _authorRepository.Add(author);

            await SaveChanges();
        }

        public async Task Delete(AuthorViewModel authorViewModel)
        {
            var author = _mapper.Map<Author>(authorViewModel);
            _authorRepository.Delete(author);

            await SaveChanges();
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorRepository.GetAll());
        }

        // TODO: Resolve
        public async Task<IEnumerable<AuthorViewModel>> GetAllAuthorBooks(ICollection<Book> books)
        {
            return _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorRepository.GetAllAuthorBooks(books));
        }

        public async Task<AuthorViewModel> GetById(Guid id)
        {
            return _mapper.Map<AuthorViewModel>(await _authorRepository.GetById(id));
        }

        public async Task Update(AuthorViewModel authorViewModel)
        {
            var author = _mapper.Map<Author>(authorViewModel);
            _authorRepository.Update(author);

            await SaveChanges();
        }

        public async Task<AuthorViewModel> GetByDoc(Document cpf)
        {
            return _mapper.Map<AuthorViewModel>(await _authorRepository.GetByDoc(cpf));
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
