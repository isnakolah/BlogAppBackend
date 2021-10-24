using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult>> CreateAuthor([FromBody] CreateAuthorDTO user)
        {
            return Created("", await _authorService.CreateAuthorAsync(user));
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedServiceResult<GetAuthorDTO>>> GetPaginatedAuthors()
        {
            return Ok(await _authorService.GetPaginatedAuthorsAsync());
        }
    }
}
