using BookManager.Domain.Events;
using BookManager.Domain.Repository;
using BookManager.Core.Communication.MediatR;
using System;
using System.Threading.Tasks;

namespace BookManager.Domain.Service
{
    public class StorageService : IStorageService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMediatrHandler _mediatrHandler;

        public StorageService(IBookRepository bookRepository, IMediatrHandler mediatrHandler)
        {
            _mediatrHandler = mediatrHandler;
        }

        public async Task<bool> DebitStock(Guid bookId, int amount)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null) return false;
            if (!book.IsThereInStock(amount)) return false;

            book.DebitStock(amount);

            // TODO: Set the low inventory quantity
            if (book.StockQuantity < 10)
            {
                await _mediatrHandler.PublishEvent(new BookBelowStockEvent(book.Id, book.StockQuantity));
            }

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
