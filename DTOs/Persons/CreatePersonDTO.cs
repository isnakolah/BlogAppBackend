using AutoMapper;

using Blog.Common.Mapping;
using Blog.DTOs.PhoneNumbers;
using Blog.DTOs.Users.Resolvers;
using Blog.Models.Entities;

namespace Blog.DTOs.Persons;

public class CreatePersonDTO : IMapTo<Person>, IMapToEntity<Person>
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
        profile.CreateMap<CreatePersonDTO, Person>()
            .ForMember(dest => dest.Sex, opt => opt.MapFrom<GenderResolver>());
    }

    public Person MapToEntity(IMapper mapper)
    {
        return mapper.Map<Person>(this);
    }
}
