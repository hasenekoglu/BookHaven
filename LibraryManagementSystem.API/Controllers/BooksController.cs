using LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookCommand createBookCommand)
        {
            CreateBookResponse response = await _mediator.Send(createBookCommand);
            return Ok(response);
        }
    }
}
