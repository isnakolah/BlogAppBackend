using AutoMapper.QueryableExtensions;

using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.Models.Common;

using Microsoft.EntityFrameworkCore;

namespace Blog.Services;

public class PaginationService : IPaginationService
{
    private readonly AutoMapper.IConfigurationProvider _mapperConfig;

    public PaginationService(AutoMapper.IConfigurationProvider mapperConfig)
    {
        _mapperConfig = mapperConfig;
    }

    public async Task<PaginatedServiceResult<TOut>> GetPaginatedDataAsync<TIn, TOut>(
        IQueryable<TIn> source)
        where TIn : AuditableEntity where TOut : class
    {
        var pageNumber = 1;

        var pageSize = 10;

        var data = await source
            .AsNoTracking()
            .ProjectTo<TOut>(_mapperConfig)
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
