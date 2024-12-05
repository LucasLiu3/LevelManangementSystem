using LevelManangementSystem.web.Models.LeaveTypes;
using LevelManangementSystem.web.Models.Periods;

namespace LevelManangementSystem.web.Models.LeaveAllocations
{
    public class LeaveAllocationViewModel
    {

        public int Id { get; set; }

        [Display(Name="Number of Days")]
        public int Days { get; set; }


        [Display(Name ="Allocation Period")]
        public PeriodViewModel Period { get; set; } = new PeriodViewModel();

        public LeaveTypeReadOnlyViewModel LeaveType { get; set; } = new LeaveTypeReadOnlyViewModel(); 



    }
}
