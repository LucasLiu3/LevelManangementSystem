using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LevelManangementSystem.web.Data;
using LevelManangementSystem.web.Models.LeaveTypes;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LevelManangementSystem.web.Services;
using System.Runtime.InteropServices;

namespace LevelManangementSystem.web.Controllers
{
    public class LeaveTypesController(ILeaveTypeService leaveTypeService) : Controller
    {

        //********因为创建了service，所以这里controller里面不会放任何数据和商业逻辑的代码
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;

        //public LeaveTypesController(ApplicationDbContext context,IMapper mapper)
        //{
        //    _context = context;
        //    this._mapper = mapper;
        //}

        public readonly ILeaveTypeService _leaveTypeService =leaveTypeService;


        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            //var data = await _context.LeaveTypes.ToListAsync();

            /////// 这是创建viewModel的直接方法
            ////在model的文件夹下创建了个indexViewModel, 用来储存数据库拿来的数据，命名规则上最好和数据库一样的字段名，这样做的原因是防止数据泄露
            ////var convertedDate = data.Select(each => new IndexViewModel
            ////{
            ////    Id = each.Id,
            ////    Name = each.Name,
            ////    NumberOfDays = each.NumberOfDays,
            ////});

            //////这里是用autoMapper的方法
            //var mappedData = _mapper.Map<List<LeaveTypeReadOnlyViewModel>>(data);

            var mappedDate = await _leaveTypeService.GetAllLeaveType();
            return View(mappedDate);  
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            //var mappedSingleLeaveType = _mapper.Map<LeaveTypeReadOnlyViewModel>(leaveType);

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateViewModel leaveTypeCreate)
        {

            //自定义函数，取查询type是否已经存在

            if (await _leaveTypeService.CheckAnyLeaveTypeExist(leaveTypeCreate.Name))
            {

                ModelState.AddModelError(nameof(leaveTypeCreate.Name), "This leave type is already exist");
            }

            if (ModelState.IsValid)
            {

                //var convertedLeaveType = _mapper.Map<LeaveType>(leaveTypeCreate);

                //_context.Add(convertedLeaveType);
                //await _context.SaveChangesAsync();

                await _leaveTypeService.Create(leaveTypeCreate);

                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

 

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes.FindAsync(id);

            var leaveType = await _leaveTypeService.Get<LeaveTypeEditViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            //var convertedDate = _mapper.Map<LeaveTypeEditViewModel>(leaveType);

            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditViewModel leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypeService.CheckAnyLeaveTypeExistForEdit(leaveTypeEdit))
            {

                ModelState.AddModelError(nameof(leaveTypeEdit.Name), "This leave type is already exist");
            }



            if (ModelState.IsValid)
            {
                try
                {

                    //var convertedLeaveType = _mapper.Map<LeaveType>(leaveTypeEdit);

                    //_context.Update(convertedLeaveType);
                    //await _context.SaveChangesAsync();

                    await _leaveTypeService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypeService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

  

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            //var convertedDate = _mapper.Map<LeaveTypeReadOnlyViewModel>(leaveType);

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);

            //if (leaveType != null)
            //{
            //    _context.LeaveTypes.Remove(leaveType);
            //}

            //await _context.SaveChangesAsync();

            await _leaveTypeService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

     
    }
}
