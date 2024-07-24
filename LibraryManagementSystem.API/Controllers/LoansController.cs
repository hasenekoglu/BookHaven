using LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan;
using LibraryManagementSystem.Application.Features.Commands.LoanCommands.DeleteLoan;
using LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;
using LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetAllLoanQuery;
using LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetByIdLoanQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan([FromBody] CreateLoanCommand createLoanCommand)
        {
            CreateLoanResponse response = await _mediator.Send(createLoanCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById([FromRoute] Guid id)
        {
            GetByIdLoanQuery query = new(){Id = id};
            GetByIdLoanResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan([FromRoute] Guid id)
        {
            DeleteLoanResponse response = await _mediator.Send(new DeleteLoanCommand(id));
            return Ok($"{response.Id} Başarıyla kaldırıldı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoan()
        {
            var response = await _mediator.Send(new GetAllLoanQuery());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoan([FromBody] UpdateLoanCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
