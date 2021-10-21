using AutoMapper;
using Blog.Common.Interfaces;
using Blog.Common.Mapping;
using Blog.DTOs.PhoneNumbers;
using Blog.Models.Entities;
using System;

namespace Blog.DTOs.Users
{
    public class CreateUserDTO : IMapTo<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } 

        public string UserName { get; set; }

        public Guid SexID { get; set; }

        public CreatePhoneNumberDTO PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.Sex, opt => opt.MapFrom<GenderResolver>());
        }

        public User MapToUser(IMapper mapper)
        {
            return mapper.Map<User>(this);
        }
    }

    public class GenderResolver : IValueResolver<CreateUserDTO, User, Sex>
    {
        private readonly IApplicationDbContext _context;

        public GenderResolver(IApplicationDbContext context)
        {
            _context = context;
        }

        public Sex Resolve(CreateUserDTO source, User destination, Sex destMember, ResolutionContext context)
        {
            var sex = _context.Sexes.Find(source.SexID);

            if (sex is null)
                throw new Exception($"Sex with id {source.SexID} not found");

            return sex;
        }

    }
}
