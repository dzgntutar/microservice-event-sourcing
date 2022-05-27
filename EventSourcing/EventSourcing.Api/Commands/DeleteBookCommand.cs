using MediatR;

namespace EventSourcing.Api.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
