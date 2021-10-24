using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Mapping;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.BlogPosts
{
    public class CreateBlogPostDTO : IMapTo<BlogPost>, IMapToEntity<BlogPost>
    {
        public Guid AuthorID { get; set; }

        public string Text { get; set; }

        public int AgeRestrictions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBlogPostDTO, BlogPost>()
                .ForMember(dest => dest.Author, 
                    opt => opt.MapFrom<AuthorResolver>());
        }

        public BlogPost MapToEntity(IMapper mapper)
        {
           return mapper.Map<BlogPost>(this);
        }
    }

    public class AuthorResolver : IValueResolver<CreateBlogPostDTO, BlogPost, Author>
    {
        private readonly IApplicationDbContext _context;

        public AuthorResolver(IApplicationDbContext context)
        {
            _context = context;
        }

        public Author Resolve(CreateBlogPostDTO source, BlogPost destination, Author destMember, ResolutionContext context)
        {
            var author = _context.Authors.Find(source.AuthorID);

            if (author is null)
                throw new Exception($"Author with ID {source.AuthorID} not found");

            return author;
        }
    }
}
