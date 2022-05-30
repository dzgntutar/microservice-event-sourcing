using EventSourcing.Api.EventStores;
using EventSourcing.Api.Models;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;
using System.Text;
using System.Text.Json;

namespace EventSourcing.Api.BackgroundServices
{
    public class BookReadEventStore : BackgroundService
    {
        private readonly IEventStoreConnection _eventStoreConnection;
        private readonly IServiceProvider _serviceProvider;

        public BookReadEventStore(IServiceProvider serviceProvider, IEventStoreConnection eventStoreConnection)
        {
            _serviceProvider = serviceProvider;
            _eventStoreConnection = eventStoreConnection;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventStoreConnection.ConnectToPersistentSubscriptionAsync(BookStream.StreamName, BookStream.GroupName, (arg1, arg2) =>
            {
                var type = Type.GetType($"{Encoding.UTF8.GetString(arg2.Event.Metadata)}, EventSourcing.Shared");
                var data = Encoding.UTF8.GetString(arg2.Event.Data);
                var @event = JsonSerializer.Deserialize(data, type);

                using var scope = _serviceProvider.CreateScope();
                //var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Book book = null;
                switch (@event)
                {
                    case BookCreatedEvent bookCreatedEvent:
                        // İnsert data to db
                        book = new Book();
                        break;
                    case BookDeletedEvent bookDeletedEvent:
                        //Delete
                        break;
                    case BookNameChangedEvent bookNameChanged:
                        //Update
                        break;
                    case BookPriceChangedEvent bookPriceChanged:
                        //Update
                        break;  
                }

                arg1.Acknowledge(arg2.Event.EventId); //dogru islendigine dair event store'a haber ver.

            },autoAck:false);


            throw new NotImplementedException();
        }
    }
}
