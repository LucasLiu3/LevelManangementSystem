using Microsoft.VisualBasic;

namespace LevelManangementSystem.web.Models.LeaveAllocations;

public class EmployeeAllocationViewModel : EmployeeListViewModel
{



    [Display(Name = "Date Birth")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth  { get; set; }

    public bool IsCompletedAllocation { get; set; }

    public List<LeaveAllocationViewModel> leaveAllocations { get; set; }
}
