using AutoMapper;
using BookManager.Catalog.Application.ViewModels;
using BookManager.Catalog.Domain;
using BookManager.Catalog.Domain.Repository;
using BookManager.Catalog.Domain.Service;
using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public BookAppService(IBookRepository bookRepository, IStorageService storageService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task Add(BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            _bookRepository.Add(book);

            await _bookRepository.UnitOfWork.Commit();
        }

        public async Task<BookViewModel> DebitStock(Guid id, int amount)
        {
            if (!_storageService.DebitStock(id, amount).Result)
                throw new DomainException("Fail to remove from stock");

            return _mapper.Map<BookViewModel>(await _bookRepository.GetById(id));
        }

        public async Task Delete(BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            _bookRepository.Delete(book);

            await _bookRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetAll());
        }

        public async Task<BookViewModel> GetByAuthor(Document cpf)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetByAuthor(cpf));
        }

        public async Task<BookViewModel> GetByCategory(int code)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetByCategory(code));
        }

        public async Task<BookViewModel> GetById(Guid id)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetById(id));
        }

        public async Task<BookViewModel> GetByIsbn(BookIdentificator isbn)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetByIsbn(isbn));
        }

        public async Task<BookViewModel> RestoreStock(Guid id, int amount)
        {
            if (!_storageService.RestoreStock(id, amount).Result)
                throw new DomainException("Failed to replenish stock.");

            return _mapper.Map<BookViewModel>(await _bookRepository.GetById(id));
        }

        public async Task Update(BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            _bookRepository.Update(book);

            await _bookRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
            _storageService?.Dispose();
        }
    }
}
