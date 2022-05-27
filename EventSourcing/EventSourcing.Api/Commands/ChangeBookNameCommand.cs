using EventSourcing.Api.Dtos;
using MediatR;

namespace EventSourcing.Api.Commands
{
    public class ChangeBookNameCommand : IRequest
    {
        public ChangeBookNameDto ChangeBookNameDto { get; set; }
    }
}
