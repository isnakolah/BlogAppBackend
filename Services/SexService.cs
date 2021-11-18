using AutoMapper;
using AutoMapper.QueryableExtensions;

using Blog.Common.Constants;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Sexes;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Services;

public class SexService : ISexService
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;
    private readonly IApplicationDbContext _context;
    private readonly AutoMapper.IConfigurationProvider _mapperConfig;

    public SexService(IMapper mapper, IMemoryCache memoryCache, IApplicationDbContext context, AutoMapper.IConfigurationProvider mapperConfig)
    {
        _mapper = mapper;
        _context = context;
        _memoryCache = memoryCache;
        _mapperConfig = mapperConfig;
    }

    public async Task<ServiceResult<GetSexDTO[]>> GetAllSexesAsync()
    {
        if (SexesInCache(out GetSexDTO[] sexes)) return ServiceResult.Success(sexes);

        sexes = await _context.Sexes
            .ProjectTo<GetSexDTO>(_mapperConfig)
            .ToArrayAsync();

        return ServiceResult.Success(_memoryCache.Set(CacheKeys.SEXES, sexes));
    }

    public async Task<ServiceResult> CreateSex(CreateSexDTO sex)
    {
        if (await SexNameExists(sex)) throw new Exception($"Sex with name {sex.Name} already exists");

        _context.Sexes.Add(sex.MapToEntity(_mapper));

        _memoryCache.Remove(CacheKeys.SEXES);

        await _context.SaveChangesAsync();

        return ServiceResult.Success();
    }

    private bool SexesInCache(out GetSexDTO[] sexes)
    {
        return _memoryCache.TryGetValue(CacheKeys.SEXES, out sexes);
    }

    private async Task<bool> SexNameExists(CreateSexDTO sex)
    {
        return await _context.Sexes.Where(s => s.Name == sex.Name).AnyAsync();
    }
}
