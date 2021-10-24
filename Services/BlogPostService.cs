using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.BlogPosts;
using Blog.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public BlogPostService(IApplicationDbContext context, IMapper mapper, IPaginationService paginationService)
        {
            _context = context;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<ServiceResult> CreateBlogAsyncAsync(CreateBlogPostDTO newBlog)
        {
            var entity = newBlog.MapToEntity(_mapper);

            _context.BlogPosts.Add(entity);

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<PaginatedServiceResult<GetBlogPostDTO>> GetPaginatedAuthorsBlogAsync(Guid authorID)
        {
            var author = await _context.Authors.FindAsync(authorID);

            if (author is null)
                throw new Exception($"Author with ID {authorID} not found");

            var blogPostQueryable = _context.BlogPosts
                .OrderBy(blogPost => blogPost.CreatedOn)
                .Where(blogPost => blogPost.Author == author);

            var blogPosts = await _paginationService.GetPaginatedDataAsync<BlogPost, GetBlogPostDTO>(blogPostQueryable);

            return blogPosts;
        }

        public async Task<PaginatedServiceResult<GetBlogPostDTO>> GetPaginatedBlogsAsync()
        {
            var blogPostQueryable = _context.BlogPosts
                .OrderBy(blogPost => blogPost.CreatedOn);

            var blogPosts = await _paginationService.GetPaginatedDataAsync<BlogPost, GetBlogPostDTO>(blogPostQueryable);

            return blogPosts;
        }
    }
}
