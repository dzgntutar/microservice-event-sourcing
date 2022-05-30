using EventSourcing.Shared.Events;
using EventStore.ClientAPI;
using System.Text;
using System.Text.Json;

namespace EventSourcing.Api.EventStores
{
    public abstract class AbstractStream
    {
        protected readonly LinkedList<IEvent> Events = new LinkedList<IEvent>();

        private string _streamName { get; }

        private readonly IEventStoreConnection _eventStoreConnection;

        protected AbstractStream(string streamName, IEventStoreConnection eventStoreConnection)
        {
            _streamName = streamName;
            _eventStoreConnection = eventStoreConnection;
        }


        public async Task SaveAsync()
        {
            var newEvents = Events.Select(_ =>
                                                new EventData(
                                                    Guid.NewGuid(),
                                                    _.GetType().Name,
                                                    true,
                                                    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(_, inputType: _.GetType())),
                                                    Encoding.UTF8.GetBytes(_.GetType().FullName))
                                          ).ToList();
            await _eventStoreConnection.AppendToStreamAsync(_streamName, ExpectedVersion.Any, newEvents);

            Events.Clear();
        }
    }
}
