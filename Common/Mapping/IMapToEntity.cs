using AutoMapper;

namespace Blog.Common.Mapping
{
    public interface IMapToEntity<TOut> where TOut : class
    {
        TOut MapToEntity(IMapper mapper);
    }
}
