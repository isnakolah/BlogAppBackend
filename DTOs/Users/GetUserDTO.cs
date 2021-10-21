using AutoMapper;
using Blog.Common.Mapping;
using Blog.Models.Entities;
using System;

namespace Blog.Users.DTOs
{
    public class GetUserDTO : IMapFrom<User>
    {
        public Guid ID { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public bool IsAuthor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserDTO>()
                .ForMember(dest => dest.FullName, 
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PhoneNumber, 
                    opt => opt.MapFrom(src => $"{src.PhoneNumber.CountryCode}{src.PhoneNumber.Number}"))
                .ForMember(dest => dest.Sex,
                    opt => opt.MapFrom(src => src.Sex.Name))
                .ForMember(dest => dest.IsAuthor,
                    opt => opt.MapFrom(src => src.Author != null));
        }
    }
}
