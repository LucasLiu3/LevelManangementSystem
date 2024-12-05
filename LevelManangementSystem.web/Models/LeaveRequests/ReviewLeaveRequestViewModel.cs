using LevelManangementSystem.web.Models.LeaveAllocations;
using Microsoft.Build.ObjectModelRemoting;

namespace LevelManangementSystem.web.Models.LeaveRequests
{
    public class ReviewLeaveRequestViewModel : LeaveRequestReadOnlyModel
    {
        public EmployeeListViewModel Employee {  get; set; } = new EmployeeListViewModel();

        public string RequestComments { get; set; }
    }
}