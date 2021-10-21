using AutoMapper;
using Blog.Common.Mapping;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.Sexes
{
    public class GetSexDTO : IMapFrom<Sex>
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sex, GetSexDTO>();
        }
    }
}
