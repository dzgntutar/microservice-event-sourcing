using EventSourcing.Api.Dtos;
using MediatR;

namespace EventSourcing.Api.Queries
{
    public class GetAllBookQuery : IRequest<List<BookDto>>
    {
    }
}
