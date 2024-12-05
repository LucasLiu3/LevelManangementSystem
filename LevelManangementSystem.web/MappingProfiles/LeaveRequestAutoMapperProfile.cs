using AutoMapper;
using LevelManangementSystem.web.Models.LeaveAllocations;
using LevelManangementSystem.web.Models.LeaveRequests;
using LevelManangementSystem.web.Models.LeaveTypes;
using LevelManangementSystem.web.Models.Periods;

namespace LevelManangementSystem.web.MappingProfiles
{
    public class LeaveRequestAutoMapperProfile : Profile
    {


        public LeaveRequestAutoMapperProfile()
        {
            CreateMap<LeaveRequestCreatViewModel, LeaveRequest>();

        }

    }
}
