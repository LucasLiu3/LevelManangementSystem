using LevelManangementSystem.web.Models.LeaveTypes;

namespace LevelManangementSystem.web.Services
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckAnyLeaveTypeExist(string name);
        Task<bool> CheckAnyLeaveTypeExistForEdit(LeaveTypeEditViewModel leaveTypeEdit);
        Task Create(LeaveTypeCreateViewModel model);
        Task Edit(LeaveTypeEditViewModel model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyViewModel>> GetAllLeaveType();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}