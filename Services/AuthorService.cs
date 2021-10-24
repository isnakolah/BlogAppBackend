using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Authors;
using Blog.Models.Entities;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IPaginationService _paginationService;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper, IApplicationDbContext context, IPaginationService paginationService)
        {
            _mapper = mapper;
            _context = context;
            _paginationService = paginationService;
        }

        public AuthorService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateAuthorAsync(CreateAuthorDTO author)
        {
            _context.Authors.Add(author.MapToEntity(_mapper));

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<PaginatedServiceResult<GetAuthorDTO>> GetPaginatedAuthorsAsync()
        {
            var authors = await _paginationService
                .GetPaginatedDataAsync<Author, GetAuthorDTO>(_context.Authors);

            return authors;
        }
    }
}
