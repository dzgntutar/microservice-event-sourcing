using EventSourcing.Api.Commands;
using EventSourcing.Api.EventStores;
using MediatR;

namespace EventSourcing.Api.Handlers
{
    public class ChangeBookNameCommandHandler : IRequestHandler<ChangeBookNameCommand>
    {
        private readonly BookStream _bookStream;

        public ChangeBookNameCommandHandler(BookStream bookStream)
        {
            _bookStream = bookStream;
        }
        public async Task<Unit> Handle(ChangeBookNameCommand request, CancellationToken cancellationToken)
        {
            _bookStream.NameChanged(request.ChangeBookNameDto);
            await _bookStream.SaveAsync();

            return Unit.Value;
        }
    }
}
