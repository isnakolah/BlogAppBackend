using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class PaginationService : IPaginationService
    {
        private readonly IConfigurationProvider _configuration;

        public PaginationService(IConfigurationProvider configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaginatedServiceResult<TOut>> CreateAsync<TIn, TOut>(
            IQueryable<TIn> source) 
            where TIn: AuditableEntity where TOut : class
        {
            var pageNumber = 1;

            var pageSize = 10;

            var data = await source
                .AsNoTracking()
                .ProjectTo<TOut>(_configuration)
                .ToArrayAsync();

            var response = new PaginatedServiceResult<TOut> 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize, 
                Data = data 
            };

            return response;
        }
    }
}
