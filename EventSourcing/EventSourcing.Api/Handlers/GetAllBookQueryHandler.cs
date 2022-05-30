using EventSourcing.Api.Dtos;
using EventSourcing.Api.Queries;
using MediatR;

namespace EventSourcing.Api.Handlers
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookDto>>
    {
        public Task<List<BookDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            //GetData from db via orm
            throw new NotImplementedException();
        }
    }
}
