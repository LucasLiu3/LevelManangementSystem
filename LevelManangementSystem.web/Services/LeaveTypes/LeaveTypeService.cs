﻿using AutoMapper;
using LevelManangementSystem.web.Data;
using LevelManangementSystem.web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Services.LeaveTypes;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{


    public async Task<List<LeaveTypeReadOnlyViewModel>> GetAllLeaveType()
    {
        var data = await _context.LeaveTypes.ToListAsync();


        var mappedData = _mapper.Map<List<LeaveTypeReadOnlyViewModel>>(data);

        return mappedData;

    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);

        return viewData;
    }


    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditViewModel model)
    {
        var convertedLeaveType = _mapper.Map<LeaveType>(model);

        _context.Update(convertedLeaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateViewModel model)
    {
        var convertedLeaveType = _mapper.Map<LeaveType>(model);

        _context.Add(convertedLeaveType);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> CheckAnyLeaveTypeExist(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(each => each.Name.ToLower().Equals(name));

        throw new NotImplementedException();
    }

    public async Task<bool> CheckAnyLeaveTypeExistForEdit(LeaveTypeEditViewModel leaveTypeEdit)
    {

        var lowercaseName = leaveTypeEdit.Name.ToLower();

        return await _context.LeaveTypes.AnyAsync(each => each.Name.ToLower().Equals(lowercaseName) && each.Id != leaveTypeEdit.Id);

    }
    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }


    public async Task<bool> DaysExceedMaximun(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);

        return leaveType.NumberOfDays < days;

    }
}
