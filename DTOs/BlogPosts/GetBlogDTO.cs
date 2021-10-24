using AutoMapper;
using Blog.Common.Mapping;
using Blog.DTOs.Authors;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.BlogPosts
{
    public class GetBlogPostDTO : IMapFrom<BlogPost>
    {
        public Guid ID { get; set; }

        public string Text { get; set; }

        public string AgeRestrictions { get; set; }

        public GetAuthorDTO Author { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogPost, GetBlogPostDTO>();
        }
    }
}
