using AutoMapper;
using LevelManangementSystem.web.Models.LeaveRequests;
using LevelManangementSystem.web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Services.LeaveRequests
{
    public class LeaveRequestService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor,
        UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveRequestService
    {
        public async Task CacncelLeaveRequest(int leaveRequestId)

        {
            var leaveRequest = await _context.leaveRequests.FindAsync(leaveRequestId);

            leaveRequest.LeaveStatusId = (int)LeaveRequestStatusEnum.Canceled;

            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(each => each.EndDay.Year == currentDate.Year);

            var appliedDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
            var allocationToRestore = await _context.LeaveAllocations.
                FirstOrDefaultAsync
                (each => each.LeaveTypeId == leaveRequest.LeaveTypeId 
                && each.EmployeeId == leaveRequest.EmployeeId
                && each.PeriodId== period.Id);

            allocationToRestore.Days = allocationToRestore.Days + appliedDays;


            await _context.SaveChangesAsync();    
        }

        public async Task<bool> CheckRequestDaysExceedAllocationDays(LeaveRequestCreatViewModel model)
        {
            var appliedDays = model.EndDate.DayNumber - model.StartDate.DayNumber;

            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(each => each.EndDay.Year == currentDate.Year);

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var leaveAllocation = await _context.LeaveAllocations.
               FirstOrDefaultAsync(each => each.LeaveTypeId == model.LeaveTypeId && each.EmployeeId == user.Id && each.PeriodId == period.Id);

            return leaveAllocation.Days < appliedDays;
        }

        public async Task CreateLeaveRequest(LeaveRequestCreatViewModel model)
        {


           var leaveRequest = _mapper.Map<LeaveRequest>(model);

           var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            leaveRequest.EmployeeId = user.Id;

            leaveRequest.LeaveStatusId = (int)LeaveRequestStatusEnum.Pending;

            _context.Add(leaveRequest);
            
           
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(each => each.EndDay.Year == currentDate.Year);

            var appliedDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
            var allocationToDeduction = await _context.LeaveAllocations.
                FirstOrDefaultAsync(each => each.LeaveTypeId == model.LeaveTypeId && each.EmployeeId == user.Id && each.PeriodId == period.Id);

            allocationToDeduction.Days = allocationToDeduction.Days - appliedDays;

            await _context.SaveChangesAsync();

        }

        public async Task<EmployeeLeaveRequestViewModel> AdminGetAllLeaveRequest()
        {
            var leaveRequests = await _context.leaveRequests
                .Include(x => x.LeaveType).ToListAsync();

            var leaveRequestConverted = leaveRequests.Select(each => new LeaveRequestReadOnlyModel
            {
                StartDate = each.StartDate,
                EndDate = each.EndDate,
                Id = each.Id,
                LeaveType = each.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)each.LeaveStatusId,
                NumberOfDays = each.EndDate.DayNumber - each.StartDate.DayNumber,
            }).ToList();



            var model = new EmployeeLeaveRequestViewModel
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(each => each.LeaveStatusId == (int)LeaveRequestStatusEnum.Approved),
                PendingRequests = leaveRequests.Count(each => each.LeaveStatusId == (int)LeaveRequestStatusEnum.Pending),
                DeclinedRequests = leaveRequests.Count(each => each.LeaveStatusId == (int)LeaveRequestStatusEnum.Declined),
                LeaveRequests = leaveRequestConverted
            };

            return model;
        }

        public async Task<List<LeaveRequestReadOnlyModel>> GetEmployeeLeaveRequest()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var leaveRequests = await _context.leaveRequests
                .Include(x => x.LeaveType)
                .Where(each=> each.EmployeeId == user.Id).ToListAsync();

            var model = leaveRequests.Select(each => new LeaveRequestReadOnlyModel
            {
                StartDate = each.StartDate,
                EndDate = each.EndDate, 
                Id = each.Id,
                LeaveType= each.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)each.LeaveStatusId,
                NumberOfDays = each.EndDate.DayNumber - each.StartDate.DayNumber,
            }).ToList();

            return model;
        }

        public async Task ReviewLeaveRequest(int id, bool approved)
        {
            var leaveRequest = await _context.leaveRequests.FindAsync(id);
            
            leaveRequest.LeaveStatusId = approved ? (int)LeaveRequestStatusEnum.Approved : (int)LeaveRequestStatusEnum.Declined;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            leaveRequest.ReviewerId = user.Id;

            if (!approved)
            {
                var currentDate = DateTime.Now;
                var period = await _context.Periods.SingleAsync(each => each.EndDay.Year == currentDate.Year);

                var appliedDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
                var allocationToRestore = await _context.LeaveAllocations.
                    FirstOrDefaultAsync(each => each.LeaveTypeId == 
                    leaveRequest.LeaveTypeId 
                    && each.EmployeeId == leaveRequest.EmployeeId 
                    && each.PeriodId == period.Id);

                allocationToRestore.Days = allocationToRestore.Days + appliedDays;
            }

            await _context.SaveChangesAsync();
        }

        

        public async Task<ReviewLeaveRequestViewModel> GetLeaveRequestForReview(int id)
        {
            var leaveRequests = await _context.leaveRequests
                .Include(x => x.LeaveType)
                .FirstAsync(each => each.Id == id);

            var user = await _userManager.FindByIdAsync(leaveRequests.EmployeeId);

            var model = new ReviewLeaveRequestViewModel { 
            
            Id = leaveRequests.Id,
            StartDate= leaveRequests.StartDate,
            EndDate= leaveRequests.EndDate, 
            NumberOfDays = leaveRequests.EndDate.DayNumber - leaveRequests.StartDate.DayNumber, 
            LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequests.LeaveStatusId,
            LeaveType = leaveRequests.LeaveType.Name,
            RequestComments = leaveRequests.RequestComment,
            Employee = new EmployeeListViewModel
            {
                Id = leaveRequests.EmployeeId,
                Email= user.Email,
                FirstName= user.FirstName,
                LastName= user.LastName,    
            }

            };

            return model;

        }
    }
}
