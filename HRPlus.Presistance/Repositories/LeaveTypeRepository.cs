using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRPlus.Presistance.Repositories
{
    public class LeaveTypeRepository : GenericRespostiory<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRPlusDbContext context) : base(context)
        {
        }

        public async Task<bool> ILeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(q => q.Name == name) == false;
        }
    }

}
