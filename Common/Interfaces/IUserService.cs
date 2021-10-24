using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Users;
using Blog.Users.DTOs;
using System;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult> CreateUserAsync(CreateUserDTO userDTO);

        Task<ServiceResult<GetUserDTO>> GetUserByIDAsync(Guid id);

        Task<PaginatedServiceResult<GetUserDTO>> GetPaginatedUsersAsync();
    }
}
