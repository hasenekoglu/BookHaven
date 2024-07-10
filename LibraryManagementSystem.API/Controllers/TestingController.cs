using LibraryManagementSystem.Application.Features.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize( AuthenticationSchemes = "Admin")]
    public class TestingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
    }
}
