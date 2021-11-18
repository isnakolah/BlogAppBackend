using AutoMapper;
using Blog.Common.Mapping;
using Blog.Models.Entities;

namespace Blog.DTOs.PhoneNumbers;

public class CreatePhoneNumberDTO : IMapTo<PhoneNumber>
{
    public string CountryCode { get; set; }

    public string Number { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePhoneNumberDTO, PhoneNumber>();
    }
}
