using EventSourcing.Api.Dtos;
using MediatR;

namespace EventSourcing.Api.Commands
{
    public class CreateBookCommand : IRequest
    {
        public CreateBookDto CreateBookDto { get; set; }
    }
}
