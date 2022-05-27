using EventSourcing.Api.Dtos;
using MediatR;

namespace EventSourcing.Api.Commands
{
    public class ChangeBookPriceCommand : IRequest
    {
        public ChangeBookPriceDto ChangeBookPriceDto { get; set; }
    }
}
