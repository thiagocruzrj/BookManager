using MediatR;
using System;

namespace BookManager.Core.Messages
{
    public abstract class Message : IRequest<bool>
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
