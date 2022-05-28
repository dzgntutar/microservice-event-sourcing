using EventSourcing.Api.Dtos;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;

namespace EventSourcing.Api.EventStores
{
    public class BookStream : AbstractStream
    {
        public static string StreamName => "BookStream";
        public BookStream( IEventStoreConnection eventStoreConnection) : base(StreamName, eventStoreConnection)
        {
        }

        public void Created(CreateBookDto createBookDto)
        {
            Events.AddLast(new BookCreatedEvent
            {
                Id = Guid.NewGuid(),
                Name = createBookDto.Name,
                Author = createBookDto.Author,
                Price = createBookDto.Price,
                Stock = createBookDto.Stock,
                Year = createBookDto.Year,
            });
        }

        public void NameChanged(ChangeBookNameDto changeBookNameDto)
        {
            Events.AddLast(new BookNameChangedEvent
            {
                Id = changeBookNameDto.Id,
                NewName = changeBookNameDto.NewName
            });
        }

        public void PriceChanged(BookPriceChangedEvent bookPriceChangedEvent)
        {
            Events.AddLast(new BookPriceChangedEvent
            {
                Id = bookPriceChangedEvent.Id,
                NewPrice = bookPriceChangedEvent.NewPrice,
            });
        }

        public void Deleted(BookDeletedEvent bookDeletedEvent)
        {
            Events.AddLast(new BookDeletedEvent
            {
                Id = bookDeletedEvent.Id
            });
        }
    }
}
