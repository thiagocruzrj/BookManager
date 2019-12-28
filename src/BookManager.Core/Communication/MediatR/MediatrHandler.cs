using BookManager.Core.Commands;
using BookManager.Core.Messages;
using MediatR;
using System.Threading.Tasks;

namespace BookManager.Core.Communication.MediatR
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MediatrHandler(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
