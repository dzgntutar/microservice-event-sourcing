using EventSourcing.Api.Dtos;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;

namespace EventSourcing.Api.EventStores
{
    public class BookStream : AbstractStream
    {
        public static string StreamName => "BookStream";
        public static string GroupName => "firstgroup";

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

        public void PriceChanged(ChangeBookPriceDto changeBookPriceDto)
        {
            Events.AddLast(new BookPriceChangedEvent
            {
                Id = changeBookPriceDto.Id,
                NewPrice = changeBookPriceDto.NewPrice,
            });
        }

        public void Deleted(Guid Id)
        {
            Events.AddLast(new BookDeletedEvent
            {
                Id = Id
            });
        }
    }
}
