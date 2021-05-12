using AutoMapper;
using SocialMediaWebAPI.DataTransferObjects;
using SocialMediaWebAPI.Models;

namespace SocialMediaWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
