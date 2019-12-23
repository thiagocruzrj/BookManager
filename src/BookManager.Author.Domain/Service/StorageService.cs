using BookManager.Catalog.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace BookManager.Catalog.Domain.Service
{
    public class StorageService : IStorageService
    {
        private readonly IBookRepository _bookRepository;
        public StorageService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> DebitStock(Guid bookId, int amount)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null) return false;
            if (!book.IsThereInStock(amount)) return false;

            book.DebitStock(amount);
            _bookRepository.Update(book);
            return await _bookRepository.UnitOfWork.Commit();
        }

        public async Task<bool> RestoreStock(Guid bookId, int amount)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null) return false;
            book.RestoreStock(amount);

            _bookRepository.Update(book);
            return await _bookRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }
    }
}
