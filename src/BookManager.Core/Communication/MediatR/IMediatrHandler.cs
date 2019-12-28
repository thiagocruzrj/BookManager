using BookManager.Core.Commands;
using BookManager.Core.Messages;
using System.Threading.Tasks;

namespace BookManager.Core.Communication.MediatR
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
