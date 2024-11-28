using AutoMapper;
using LevelManangementSystem.web.Data;
using LevelManangementSystem.web.Models.LeaveTypes;

namespace LevelManangementSystem.web.MappingProfiles
{
    public class AutoMappeingProfile : Profile
    {

        public AutoMappeingProfile() {

            //这里就会对里面两个数据的数据进行转换
            //所以数据库里的字段名和viewmodel里面的字段名必须一样，不然automapper就不会进行转换
            CreateMap<LeaveType, LeaveTypeReadOnlyViewModel>(); 

            CreateMap<LeaveTypeCreateViewModel,LeaveType>();

            //加ReverseMap,两边的数据都能互相map转换
            CreateMap<LeaveTypeEditViewModel, LeaveType>().ReverseMap();

                
        }
    }
}
