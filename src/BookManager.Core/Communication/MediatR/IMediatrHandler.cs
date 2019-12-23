using BookManager.Core.Messages;
using System.Threading.Tasks;

namespace BookManager.Core.Communication.MediatR
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
    }
}
