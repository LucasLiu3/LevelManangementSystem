using AutoMapper;
using LevelManangementSystem.web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, 
        UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveAllocationsService
    {
        private async Task<bool> AllocationExists(string Id, int periodId, int leaveTypeId)
        {
            var exist = await _context.LeaveAllocations.AnyAsync(each=>
            each.EmployeeId == Id && each.LeaveTypeId == leaveTypeId && each.PeriodId == periodId);

            return exist;
        }


        
        public async Task AllocateLeave(string employeeId)
        {
            var allLeaveType = await  _context.LeaveTypes
                .Where(each=> !each.LeaveAllocations.Any(allocation=> allocation.EmployeeId == employeeId))
                .ToListAsync();
      

            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(each=> each.EndDay.Year == currentDate.Year);
            var monthsReamining = period.EndDay.Month - currentDate.Month;

            foreach (var leaveType in allLeaveType)
            {

                //var allcationExists = await AllocationExists(employeeId,period.Id,leaveType.Id);

                //if (allcationExists) {
                //    continue;
                //}
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsReamining)
                };


                _context.Add(leaveAllocation);
            }
            
            await _context.SaveChangesAsync();

        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? id)
        {

            //var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            //string employeeId = string.Empty;

            //if (string.IsNullOrEmpty(id))
            //{
            //    employeeId = id;
            //}
            //else
            //{
            //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            //    employeeId = user.Id;
            //}

            
            var currentDate = DateTime.Now;

            var allAllocations = await _context.LeaveAllocations
                .Include(each=> each.LeaveType)
                .Include(each=> each.Period)   
                .Where(each=>each.EmployeeId == id && each.Period.EndDay.Year == currentDate.Year).ToListAsync();


            return allAllocations;
        }
         
        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocation(string? id)
        {
            var user = string.IsNullOrEmpty(id)
                    ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
                    : await _userManager.FindByIdAsync(id);

            var allocations = await GetAllocations(user.Id);

            var allocationViewModelList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationViewModel>>(allocations);

            var leaveTypesCount = await _context.LeaveTypes.CountAsync();

            //var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);



            var employeeViewModel = new EmployeeAllocationViewModel
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                leaveAllocations = allocationViewModelList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count,

            };

            return employeeViewModel;
        }

        public async Task<LeaveAllocationEditViewModel> GetEmployeeSingleAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations.Include(each=>each.LeaveType)
                .Include(each=>each.Employee)
                .FirstOrDefaultAsync(each=> each.Id == allocationId);


            var modelAllocation = _mapper.Map<LeaveAllocationEditViewModel>(allocation);

            return modelAllocation;
        }


        public async Task EditAllocation(LeaveAllocationEditViewModel allocationEditViewModel)
        {
            //var leaveAllocation = await GetEmployeeSingleAllocation(allocationEditViewModel.Id);

            //if (leaveAllocation == null) {

            //    throw new Exception("Leave allocation does not exist");
            //}

            //leaveAllocation.Days = allocationEditViewModel.Days;

            //_context.Update(leaveAllocation);
            //_context.SaveChangesAsync();


            //另外一种写法
            _context.LeaveAllocations.Where(each => each.Id == allocationEditViewModel.Id)
                .ExecuteUpdateAsync(data => data.SetProperty(property => property.Days, allocationEditViewModel.Days));
        }



        public async Task<List<EmployeeListViewModel>> GetEmployee()
        {

            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListViewModel>>(users.ToList());

            return employees;
        }

    }
}
