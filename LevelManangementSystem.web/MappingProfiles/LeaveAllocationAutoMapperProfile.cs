using AutoMapper;
using LevelManangementSystem.web.Models.LeaveAllocations;
using LevelManangementSystem.web.Models.Periods;

namespace LevelManangementSystem.web.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {


        public LeaveAllocationAutoMapperProfile() {

            CreateMap<LeaveAllocation, LeaveAllocationViewModel>();

            CreateMap<ApplicationUser, EmployeeListViewModel>();

            CreateMap<Period, PeriodViewModel>();


            CreateMap<LeaveAllocation, LeaveAllocationEditViewModel>();
        }

    }
}
