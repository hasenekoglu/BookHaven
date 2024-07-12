using LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook;
using LibraryManagementSystem.Application.Features.Commands.BookCommands.DeleteBook;
using LibraryManagementSystem.Application.Features.Commands.BookCommands.UpdateBook;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetAllBooksQuery;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;
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
        public async Task<IActionResult> AddBook([FromBody] CreateBookCommand createBookCommand)
        {
            CreateBookResponse response = await _mediator.Send(createBookCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            GetByIdBookQuery query = new(){Id = id};
            GetByIdBookResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
           DeleteBookResponse response = await _mediator.Send(new DeleteBookCommand(id));
            return Ok($"{response} Başarıyla kaldırıldı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var response = await _mediator.Send(new GetAllBooksQuery());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
