using EventSourcing.Api.Commands;
using EventSourcing.Api.EventStores;
using MediatR;

namespace EventSourcing.Api.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly BookStream _bookStream;

        public CreateBookCommandHandler(BookStream bookStream)
        {
            _bookStream = bookStream;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            _bookStream.Created(request.CreateBookDto);
            await _bookStream.SaveAsync();

            return Unit.Value;
        }
    }
}
