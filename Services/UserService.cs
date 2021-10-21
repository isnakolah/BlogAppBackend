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
        private readonly IPaginationService _paginationService;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(
            IApplicationDbContext context,
            IMapper mapper,
            IPaginationService paginationService)
        {
            _context = context;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<ServiceResult> CreateUser(CreateUserDTO user)
        {
            await _context.Users.AddAsync(user.MapToUser(_mapper));

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<PaginatedServiceResult<GetUserDTO>> GetPaginatedUsers()
        {
            var users = await _paginationService.CreateAsync<User, GetUserDTO>(_context.Users);

            return users;
        }

        public Task<ServiceResult<GetUserDTO>> GetUserByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
