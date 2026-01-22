using Application.Activities.DTOs;
using Application.Users;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<User, UserSummaryDto>();
        }
    }
}
