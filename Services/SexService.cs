﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Common.Constants;
using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Sexes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class SexService : ISexService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IConfigurationProvider _configuration;

        public SexService(
            IApplicationDbContext context, 
            IConfigurationProvider configuration, 
            IMemoryCache memoryCache, 
            IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<ServiceResult<GetSexDTO[]>> GetAllSexes()
        {
            if (_memoryCache.TryGetValue(CacheKeys.SEXES, out GetSexDTO[] sexes))
                return ServiceResult.Success(sexes);

            sexes = await _context.Sexes
                .ProjectTo<GetSexDTO>(_configuration)
                .ToArrayAsync();

            return ServiceResult.Success(_memoryCache.Set(CacheKeys.SEXES, sexes));
        }

        public async Task<ServiceResult> CreateSex(CreateSexDTO sex)
        {
            if (await SexNameExists(sex))
                throw new Exception($"Sex with name {sex.Name} already exists");

            _context.Sexes.Add(sex.MapToSex(_mapper));

            _memoryCache.Remove(CacheKeys.SEXES);

            await _context.SaveChangesAsync();

            return ServiceResult.Success();
        }

        private async Task<bool> SexNameExists(CreateSexDTO sex)
        {
            return await _context.Sexes.Where(s => s.Name == sex.Name).AnyAsync();
        }
    }
}
