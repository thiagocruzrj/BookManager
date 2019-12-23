using System;
using MediatR;

namespace BookManager.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
