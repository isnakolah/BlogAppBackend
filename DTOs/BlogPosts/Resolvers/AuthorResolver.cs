using AutoMapper;

using Blog.Common.Interfaces;
using Blog.Models.Entities;

namespace Blog.DTOs.BlogPosts.Resolvers;

public class AuthorResolver : IValueResolver<CreateBlogPostDTO, BlogPost, Author>
{
    private readonly IApplicationDbContext _context;

    public AuthorResolver(IApplicationDbContext context) => _context = context;

    public Author Resolve(CreateBlogPostDTO source, BlogPost destination, Author destMember, ResolutionContext context)
    {
        var author = _context.Authors.Find(source.AuthorID);

        if (author is null) throw new Exception($"Author with ID {source.AuthorID} not found");

        return author;
    }
}