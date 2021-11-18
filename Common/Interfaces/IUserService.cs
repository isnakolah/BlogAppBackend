using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Persons;

using System;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult> CreateUserAsync(CreatePersonDTO userDTO);

        Task<ServiceResult<GetPersonDTO>> GetUserByIDAsync(Guid id);

        Task<PaginatedServiceResult<GetPersonDTO>> GetPaginatedUsersAsync();
    }
}
