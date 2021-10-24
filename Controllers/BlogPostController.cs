using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.BlogPosts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class BlogPostController : BaseApiController
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedServiceResult<GetBlogPostDTO>>> GetPaginatedBlogs()
        {
            return Ok(await _blogPostService.GetPaginatedBlogsAsync());
        }

        [HttpGet]
        [Route("author/{authorID:guid}")]
        public async Task<ActionResult<PaginatedServiceResult<GetBlogPostDTO>>> GetPaginatedAuthorBlogs([FromRoute] Guid authorID)
        {
            return Ok(await _blogPostService.GetPaginatedAuthorsBlogAsync(authorID));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult>> CreateBlog([FromBody] CreateBlogPostDTO newBlog)
        {
            return Created("", await _blogPostService.CreateBlogAsyncAsync(newBlog));
        }
    }
}
