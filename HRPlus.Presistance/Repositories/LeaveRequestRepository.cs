using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRPlus.Presistance.Repositories
{
    public class LeaveRequestRepository : GenericRespostiory<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRPlusDbContext context) : base(context)
        {

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveRequests;
        }
        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                .Where(q => q.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }
        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {

            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest!;
        }
    }

}
