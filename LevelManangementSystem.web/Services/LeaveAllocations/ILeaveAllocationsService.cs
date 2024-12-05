using LevelManangementSystem.web.Models.LeaveAllocations;

namespace LevelManangementSystem.web.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
        Task EditAllocation(LeaveAllocationEditViewModel allocationEditViewModel);

        //Task<List<LeaveAllocation>> GetAllocations(string? id);

        Task<List<EmployeeListViewModel>> GetEmployee();
        Task<EmployeeAllocationViewModel> GetEmployeeAllocation(string? id);

        Task<LeaveAllocationEditViewModel> GetEmployeeSingleAllocation(int allocationId);
    }
}
