﻿using System.ComponentModel;
using LevelManangementSystem.web.Services.LeaveRequests;

namespace LevelManangementSystem.web.Models.LeaveRequests
{
    public class LeaveRequestReadOnlyModel
    {
        public int Id { get; set; }

        [DisplayName("Start Date")]
        public DateOnly StartDate { get; set; }

        [DisplayName("End Date")]
        public DateOnly EndDate { get; set; }

        [DisplayName("Total Days")]
        public int NumberOfDays  { get; set; }

        [DisplayName("Leave Type")]
        public string LeaveType  { get; set; }= string.Empty;

        [DisplayName("Status")]
        public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }   

    }
}