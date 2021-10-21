using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Authors;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public AuthorService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateAuthor(CreateAuthorDTO author)
        {
            _context.Authors.Add(author.MapToEntity(_mapper));

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }
    }
}
