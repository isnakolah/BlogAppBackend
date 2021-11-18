using AutoMapper;

using Blog.Common.Mapping;
using Blog.DTOs.Authors.Resolvers;
using Blog.Models.Entities;

namespace Blog.DTOs.Authors
{
    public class CreateAuthorDTO : IMapTo<Author>, IMapToEntity<Author>
    {
        public string Alias { get; set; }

        public Guid UserID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDTO, Author>()
                .ForMember(dest => dest.User, opt => opt.MapFrom<UserResolver>());
        }

        public Author MapToEntity(IMapper mapper)
        {
            return mapper.Map<Author>(this);
        }
    }
}
