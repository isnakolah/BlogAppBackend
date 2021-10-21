using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Mapping;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.Authors
{
    public class CreateAuthorDTO : IMapTo<Author>, IMapping<Author>
    {
        public string Alias { get; set; }

        public Guid UserID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDTO, Author>()
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom<UserResolver>());
        }

        public Author MapToEntity(IMapper mapper)
        {
            return mapper.Map<Author>(this);
        }
    }

    public class UserResolver : IValueResolver<CreateAuthorDTO, Author, User>
    {
        private readonly IApplicationDbContext _context;

        public UserResolver(IApplicationDbContext context)
        {
            _context = context;
        }

        public User Resolve(CreateAuthorDTO source, Author destination, User destMember, ResolutionContext context)
        {
            var user = _context.Users.Find(source.UserID);

            if (user is null)
                throw new Exception($"User with id {source.UserID} not found");

            return user;
        }
    }
}
