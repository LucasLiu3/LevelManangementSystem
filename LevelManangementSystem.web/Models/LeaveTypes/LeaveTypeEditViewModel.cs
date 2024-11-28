using System.ComponentModel.DataAnnotations;

namespace LevelManangementSystem.web.Models.LeaveTypes
{
    public class LeaveTypeEditViewModel : BaseLeaveTypeViewModel
    {

        [Required]
        [Length(4, 150, ErrorMessage = "Input between 4 and 150 characters")]
        public string Name { get; set; }

        [Required]
        [Range(1, 30, ErrorMessage = "Input numbers between 1 and 30")]
        public int NumberOfDays { get; set; }
    }
}
