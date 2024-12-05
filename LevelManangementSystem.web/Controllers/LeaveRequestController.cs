using AspNetCoreGeneratedDocument;
using LevelManangementSystem.web.Data;
using LevelManangementSystem.web.Models.LeaveRequests;
using LevelManangementSystem.web.Services.LeaveRequests;
using LevelManangementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LevelManangementSystem.web.Controllers
{
    [Authorize]
    public class LeaveRequestController(ILeaveTypeService _leaveTypeService, ILeaveRequestService _leaveRequestService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestService.GetEmployeeLeaveRequest();
            return View(model);
        }

        public async Task<IActionResult> Create(int? leaveTypeId)
        {
            var leaveTypes = await _leaveTypeService.GetAllLeaveType();
            var selectLeaveType = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
            var model = new LeaveRequestCreatViewModel
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                LeaveTypes = selectLeaveType,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreatViewModel model)
        {
            if (await _leaveRequestService.CheckRequestDaysExceedAllocationDays(model)) {

                ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
                ModelState.AddModelError(nameof(model.EndDate), "The number of days is invalid");
            }



            if (ModelState.IsValid)
            {
                await _leaveRequestService.CreateLeaveRequest(model);
                
                return RedirectToAction(nameof(Index));
            }

            var leaveTypes = await _leaveTypeService.GetAllLeaveType();
            var selectLeaveType = new SelectList(leaveTypes, "Id", "Name");
            model.LeaveTypes = selectLeaveType;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            await _leaveRequestService.CacncelLeaveRequest(id);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles.Admin)]
        [Authorize(Roles.Supervisor)]
        public async Task<IActionResult> ListRequests()
        {
            var model = await _leaveRequestService.AdminGetAllLeaveRequest();

            return View(model);
        }

        public async Task<IActionResult> Review(int id)
        {
            var model = await _leaveRequestService.GetLeaveRequestForReview(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, bool approved)
        {
            await _leaveRequestService.ReviewLeaveRequest(id, approved);

            return RedirectToAction(nameof(ListRequests));
        }

    }
}
