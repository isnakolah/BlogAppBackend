using AutoMapper;

using Blog.Common.Interfaces;
using Blog.Models.Entities;

namespace Blog.DTOs.Authors.Resolvers;

public class UserResolver : IValueResolver<CreateAuthorDTO, Author, Person>
{
    private readonly IApplicationDbContext _context;

    public UserResolver(IApplicationDbContext context) => _context = context;

    public Person Resolve(CreateAuthorDTO source, Author destination, Person destMember, ResolutionContext context)
    {
        var user = _context.Users.Find(source.UserID);

        if (user is null) throw new Exception($"User with id {source.UserID} not found");

        return user;
    }
}
