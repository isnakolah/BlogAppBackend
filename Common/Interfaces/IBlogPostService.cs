using Blog.Common.Models.ServiceResult;
using Blog.DTOs.BlogPosts;
using System;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IBlogPostService
    {
        Task<ServiceResult> CreateBlogAsyncAsync(CreateBlogPostDTO newBlog);

        Task<PaginatedServiceResult<GetBlogPostDTO>> GetPaginatedBlogsAsync();

        Task<PaginatedServiceResult<GetBlogPostDTO>> GetPaginatedAuthorsBlogAsync(Guid authorID);
    }
}
