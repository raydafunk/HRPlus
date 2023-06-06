using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;

namespace HRPlus.Presistance.Repositories
{
    public class LeaveAllocationRepository : GenericRespostiory<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRPlusDbContext context) : base(context)
        {

        }

    }

}
