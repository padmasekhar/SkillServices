using AutoMapper;
using SkillServices.Data.DbModels;
using Microservices.Dtos;

namespace SkillServices.Api.AutoMapperProfiles
{
    public class SkillServiceAutoMapperProfile : Profile
    {
        public SkillServiceAutoMapperProfile()
        {
            CreateMap<Skill, SkillReadDto>()
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory != null ? src.SubCategory.Name : null))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.SubCategory != null
                                                                            && src.SubCategory.Category != null
                                                                            ? src.SubCategory.Category.Name : null));

            CreateMap<SkillCreateDto, Skill>();
        }
    }
}
