
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.CreateCategory;
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.DeleteCategory;
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.UpdateCategory;
using LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetAllCategoryQuery;
using LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetByIdCategoryQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryId([FromRoute] Guid id)
        {
            GetByIdCategoryQuery query = new() { Id = id};
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            DeleteCategoryResponse response = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(response.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await _mediator.Send(updateCategoryCommand);
            return Ok(response);
        }
    }
}
