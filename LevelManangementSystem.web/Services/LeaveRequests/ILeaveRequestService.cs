using LevelManangementSystem.web.Models.LeaveRequests;

namespace LevelManangementSystem.web.Services.LeaveRequests
{
    public interface ILeaveRequestService
    {

        Task CreateLeaveRequest(LeaveRequestCreatViewModel model);

        Task<List<LeaveRequestReadOnlyModel>> GetEmployeeLeaveRequest();

        Task<EmployeeLeaveRequestViewModel> AdminGetAllLeaveRequest();

        Task CacncelLeaveRequest(int leaveRequestId);

        Task ReviewLeaveRequest(int id, bool approved);

        Task<bool> CheckRequestDaysExceedAllocationDays(LeaveRequestCreatViewModel model);
        Task<ReviewLeaveRequestViewModel> GetLeaveRequestForReview(int id);
    }
}