using AutoMapper;

using Blog.Common.Interfaces;
using Blog.DTOs.Persons;
using Blog.Models.Entities;

namespace Blog.DTOs.Users.Resolvers;

public class GenderResolver : IValueResolver<CreatePersonDTO, Person, Sex>
{
    private readonly IApplicationDbContext _context;

    public GenderResolver(IApplicationDbContext context) => _context = context;

    public Sex Resolve(CreatePersonDTO source, Person destination, Sex destMember, ResolutionContext context)
    {
        var sex = _context.Sexes.Find(source.SexID);

        if (sex is null) throw new Exception($"Sex with id {source.SexID} not found");

        return sex;
    }
}