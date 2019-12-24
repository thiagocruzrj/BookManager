using BookManager.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Events
{
    public class BookBelowStockEvent : DomainEvent
    {
        public int RemainingAmount { get; set; }
        public BookBelowStockEvent(Guid aggregateId, int remainingAmount) : base(aggregateId)
        {
            RemainingAmount = remainingAmount;
        }
    }
}
