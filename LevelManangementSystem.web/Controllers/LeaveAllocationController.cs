using LevelManangementSystem.web.Models.LeaveAllocations;
using LevelManangementSystem.web.Services.LeaveAllocations;
using LevelManangementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;

namespace LevelManangementSystem.web.Controllers
{
    [Authorize]
    public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService, ILeaveTypeService _leaveTypeService) : Controller
    {
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Index()
        {

            var allEmployees = await _leaveAllocationsService.GetEmployee();

            return View(allEmployees);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? id)
        {

            await _leaveAllocationsService.AllocateLeave(id);

            return RedirectToAction(nameof(Details),new {id});
        }



        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> EditAllocation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _leaveAllocationsService.GetEmployeeSingleAllocation(id.Value);

            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditViewModel allocationEditViewModel)
        {

            if(await _leaveTypeService.DaysExceedMaximun(allocationEditViewModel.LeaveType.Id, allocationEditViewModel.Days))
            {
                ModelState.AddModelError("Days", "The allocation exceeds the maximum");
            }


            if (ModelState.IsValid)
            {
            await _leaveAllocationsService.EditAllocation(allocationEditViewModel);

            return RedirectToAction(nameof(Details), new { allocationEditViewModel.Employee.Id });       
            }

            var days = allocationEditViewModel.Days;
            allocationEditViewModel = await _leaveAllocationsService.GetEmployeeSingleAllocation(allocationEditViewModel.Id);
            allocationEditViewModel.Days = days;

            return View(allocationEditViewModel);
        }



        public async Task<IActionResult> Details(string? id)
        {

            var allSingleUserAllocations = await _leaveAllocationsService.GetEmployeeAllocation(id);

            return View(allSingleUserAllocations);
        }
    }
}
