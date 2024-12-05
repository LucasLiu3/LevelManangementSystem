using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LevelManangementSystem.web.Models.LeaveRequests
{
    public class LeaveRequestCreatViewModel : IValidatableObject
    {

        [DisplayName("Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }


        [DisplayName("End Date")]
        [Required]
        public DateOnly EndDate { get; set; }

        [DisplayName("Desired Leave Type Date")]
        [Required]
        public int LeaveTypeId { get; set; }

        [DisplayName("Additional Information")]
        public string? RequestComment { get; set; }

        public SelectList? LeaveTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate > EndDate)
            {
                yield return new ValidationResult("Start Date must be Before the End Date ", new[] {nameof(StartDate),nameof(EndDate)});
            }
        }
    }
}