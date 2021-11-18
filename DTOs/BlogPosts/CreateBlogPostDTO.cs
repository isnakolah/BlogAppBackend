using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Mapping;
using Blog.DTOs.BlogPosts.Resolvers;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.BlogPosts;

public class CreateBlogPostDTO : IMapTo<BlogPost>, IMapToEntity<BlogPost>
{
    public Guid AuthorID { get; set; }

    public string Text { get; set; }

    public int AgeRestrictions { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateBlogPostDTO, BlogPost>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom<AuthorResolver>());
    }

    public BlogPost MapToEntity(IMapper mapper)
    {
        return mapper.Map<BlogPost>(this);
    }
}
