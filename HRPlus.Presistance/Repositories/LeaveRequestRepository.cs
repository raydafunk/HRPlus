using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;

namespace HRPlus.Presistance.Repositories
{
    public class LeaveRequestRepository : GenericRespostiory<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRPlusDbContext context) : base(context)
        {

        }

    }

}
