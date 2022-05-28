using EventSourcing.Api.Commands;
using EventSourcing.Api.EventStores;
using EventSourcing.Shared.Events;
using MediatR;

namespace EventSourcing.Api.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly BookStream _bookStream;

        public DeleteBookCommandHandler(BookStream bookStream)
        {
            _bookStream = bookStream;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            _bookStream.Deleted(request.Id);
            await _bookStream.SaveAsync();

            return Unit.Value;
        }
    }
}
