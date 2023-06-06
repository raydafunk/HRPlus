using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRPlus.Presistance.Repositories
{
    public class LeaveAllocationRepository : GenericRespostiory<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRPlusDbContext context) : base(context)
        {

        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExits(string userId, int LeaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                 && q.LeaveTypeId == LeaveTypeId
                                 && q.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
             return leaveAllocations;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocatons = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync( q => q.Id == id);
            return leaveAllocatons!;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int LeaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q=> q.EmployeeId == userId && q.LeaveTypeId == LeaveTypeId);
        }
    }

}
