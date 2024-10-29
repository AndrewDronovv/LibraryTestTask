using Library.Application.Authors.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllAuthorQuery());

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}