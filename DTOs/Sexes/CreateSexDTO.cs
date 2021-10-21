using AutoMapper;
using Blog.Common.Mapping;
using Blog.Models.Entities;

namespace Blog.DTOs.Sexes
{
    public class CreateSexDTO : IMapTo<Sex>
    {
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSexDTO, Sex>();
        }

        public Sex MapToSex(IMapper mapper)
        {
            return mapper.Map<Sex>(this);
        }
    }
}
