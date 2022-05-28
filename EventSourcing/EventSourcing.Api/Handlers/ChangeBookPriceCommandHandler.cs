using EventSourcing.Api.Commands;
using EventSourcing.Api.EventStores;
using MediatR;

namespace EventSourcing.Api.Handlers
{
    public class ChangeBookPriceCommandHandler : IRequestHandler<ChangeBookPriceCommand>
    {
        private readonly BookStream _bookStream;

        public ChangeBookPriceCommandHandler(BookStream bookStream)
        {
            _bookStream = bookStream;
        }

        public async Task<Unit> Handle(ChangeBookPriceCommand request, CancellationToken cancellationToken)
        {
            _bookStream.PriceChanged(request.ChangeBookPriceDto);
            await _bookStream.SaveAsync();

            return Unit.Value;
        }
    }
}
