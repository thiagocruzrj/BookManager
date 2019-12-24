using BookManager.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookManager.Domain.Events
{
    public class BookEventHandler : INotificationHandler<BookBelowStockEvent>
    {
        private readonly IBookRepository _bookRepository;

        public BookEventHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(BookBelowStockEvent notification, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(notification.AggregateId);
            // Send an email to buy more books
        }
    }
}
