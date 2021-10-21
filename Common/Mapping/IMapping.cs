﻿using AutoMapper;

namespace Blog.Common.Mapping
{
    public interface IMapping<TOut> where TOut : class
    {
        TOut MapToEntity(IMapper mapper);
    }
}
