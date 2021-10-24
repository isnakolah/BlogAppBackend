using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Users;
using Blog.Models.Entities;
using Blog.Users.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IPaginationService _paginationService;

        public UserService(
            IMapper mapper,
            IApplicationDbContext context,
            IPaginationService paginationService)
        {
            _mapper = mapper;
            _context = context;
            _paginationService = paginationService;
        }

        public async Task<ServiceResult> CreateUserAsync(CreateUserDTO user)
        {
            await _context.Users.AddAsync(user.MapToEntity(_mapper));

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<PaginatedServiceResult<GetUserDTO>> GetPaginatedUsersAsync()
        {
            var users = await _paginationService.GetPaginatedDataAsync<User, GetUserDTO>(_context.Users);

            return users;
        }

        public Task<ServiceResult<GetUserDTO>> GetUserByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
