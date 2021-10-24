using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Authors;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IAuthorService
    {
        Task<ServiceResult> CreateAuthor(CreateAuthorDTO author);

        Task<PaginatedServiceResult<GetAuthorDTO>> GetPaginatedAuthors();
    }
}
