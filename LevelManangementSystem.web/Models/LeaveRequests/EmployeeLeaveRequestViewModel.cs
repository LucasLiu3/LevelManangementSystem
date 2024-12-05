﻿namespace LevelManangementSystem.web.Models.LeaveRequests
{
    public class EmployeeLeaveRequestViewModel
    {

        [Display(Name = "Total Number of Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int DeclinedRequests { get; set; }


        public List<LeaveRequestReadOnlyModel> LeaveRequests { get; set; } = [];
    }
}