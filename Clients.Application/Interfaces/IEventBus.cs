
namespace Clients.Infrastructure.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}
