using EventSourcing.Api.Commands;
using EventSourcing.Api.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto createBookDto)
        {
            await _mediator.Send(new CreateBookCommand { CreateBookDto= createBookDto});

            return NoContent(); 
        }

        [HttpPut]
        public async Task<IActionResult> ChangeName(ChangeBookNameDto changeBookNameDto)
        {
            await _mediator.Send(new ChangeBookNameCommand { ChangeBookNameDto= changeBookNameDto });
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ChangePrice(ChangeBookPriceDto changeBookPriceDto)
        {
            await _mediator.Send(new ChangeBookPriceCommand { ChangeBookPriceDto=changeBookPriceDto});
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _mediator.Send(new DeleteBookCommand { Id=Id});
            return Ok();
        }
    }
}
