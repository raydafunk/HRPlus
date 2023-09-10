using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
