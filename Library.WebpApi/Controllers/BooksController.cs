using AutoMapper;
using EnumsNET;
using Library.Application.Books.Commands.Create;
using Library.Application.Books.Commands.Delete;
using Library.Application.Books.Commands.Update;
using Library.Application.Books.Quaries.GetAll;
using Library.Application.Books.Queries.Get;
using Library.Application.Dto.Books;
using Library.Domain;
using Library.Domain.Enums;
using Library.WebpApi.Dto.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(AppDbContext context, IMapper mapper, IMediator mediatr)
        {
            _context = context;
            _mapper = mapper;
            _mediatr = mediatr;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediatr.Send(new GetAllBookQuery());

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _mediatr.Send(new GetBookQuery(id));

            if (result == null)
            {
                return NotFound($"Книга с индексом = {id} не существует");
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateBookDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateBookCommand>(input);
            var result = await _mediatr.Send(command);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetGenres()
        {
            var genres = Enum.GetValues<Genre>();
            var genresDto = genres.Select(g => new GenresDto
            {
                Name = g.AsString(EnumFormat.Description),
                Value = g
            });
            return Ok(genresDto);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (input.AuthorId <= 0 || !_context.Authors.Any(a => a.Id == input.AuthorId))
            {
                return BadRequest($"Автора с индексом {input.AuthorId} не существует");
            }

            var command = _mapper.Map<UpdateBookCommand>(input);
            command.Id = id;

            var result = await _mediatr.Send(command);

            if (result == null)
            {
                return NotFound($"Книга с индексом = {id} не существует");
            }

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediatr.Send(new DeleteBookCommand(id));
            if (result == null)
            {
                return NotFound($"Книга с индексом = {id} не существует");
            }

            return Ok();
        }
    }
}