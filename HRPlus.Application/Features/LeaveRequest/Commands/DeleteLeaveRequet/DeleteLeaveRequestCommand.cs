using MediatR;

namespace HRPlus.Application.Features.LeaveRequest.Commands.DeleteLeaveRequet
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
