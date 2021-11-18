using AutoMapper;
using Blog.Common.Mapping;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.Authors;

public class GetAuthorDTO : IMapFrom<Author>
{
    public Guid ID { get; set; }

    public string Alias { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Author, GetAuthorDTO>();
    }
}
