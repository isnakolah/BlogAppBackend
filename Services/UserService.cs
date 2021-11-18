using AutoMapper;

using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Persons;
using Blog.Models.Entities;

namespace Blog.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    private readonly IPaginationService _paginationService;

    public UserService(IMapper mapper, IApplicationDbContext context, IPaginationService paginationService)
    {
        _mapper = mapper;
        _context = context;
        _paginationService = paginationService;
    }

    public async Task<ServiceResult> CreateUserAsync(CreatePersonDTO user)
    {
        await _context.Users.AddAsync(user.MapToEntity(_mapper));

        await _context.SaveChangesAsync();

        return ServiceResult.Success();
    }

    public async Task<PaginatedServiceResult<GetPersonDTO>> GetPaginatedUsersAsync()
    {
        var users = await _paginationService.GetPaginatedDataAsync<Person, GetPersonDTO>(_context.Users);

        return users;
    }

    public Task<ServiceResult<GetPersonDTO>> GetUserByIDAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
